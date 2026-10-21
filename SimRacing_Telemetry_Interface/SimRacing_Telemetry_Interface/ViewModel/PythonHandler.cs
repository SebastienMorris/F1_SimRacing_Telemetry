using System.Diagnostics;
using System.Reflection.Metadata;
using Python.Runtime;

namespace SimRacing_Telemetry_Interface.ViewModel;

static class PythonHandler
{
    private const string PythonDllPath = @"C:\Users\markm\AppData\Local\Programs\Python\Python314\python314.dll";

    private const string PythonScriptPath =
        @"C:\Users\markm\Documents\SoftwareProjects\F1_SimRacing_Telemetry\SimRacing_Telemetry_DataCore";

    private const string ScriptName = "main";

    private static bool _isInitialised = false;

    private static void Initialise()
    {
        Runtime.PythonDLL = PythonDllPath;
        PythonEngine.Initialize();
        using (Py.GIL())
        {
            dynamic sys = Py.Import("sys");
            sys.path.append(PythonScriptPath);
        }

        _isInitialised = true;
    }

    private static PyObject RunPythonFunction(string functionName, PyObject[]? args = null)
    {
        if (!_isInitialised)
        {
            Initialise();
        }

        using (Py.GIL())
        {
            var pythonScript = Py.Import(ScriptName);

            if (args == null)
                return pythonScript.InvokeMethod(functionName);
            else
                return pythonScript.InvokeMethod(functionName, args);
        }
    }

    public static void Run_SayHello()
    {
        var result = RunPythonFunction("say_hello");
        Console.WriteLine(result);
    }

    public static void Run_StartServer()
    {
        var result = RunPythonFunction("start_server");
        Console.WriteLine(result);
    }

    public static void Run_StopServer()
    {
        var result = RunPythonFunction("stop_server");
        Console.WriteLine(result);
    }

    public static (string, int) Run_GetServerAddress()
    {
        var result = RunPythonFunction("get_server_address");
        Console.WriteLine(result);

        PyTuple addressTuple = result.As<PyTuple>();

        return (addressTuple[0].As<string>(), addressTuple[1].As<int>());
    }

    public static Dictionary<string, string> Run_GetDataFromType(string dataType)
    {
        Initialise();
        PyString arg =  new PyString(dataType);
        var result = RunPythonFunction("get_data_from_type", new PyObject[]{ arg });
        Console.WriteLine(result);

        PyDict dict = result.As<PyDict>();
        Dictionary<string, string> data = new Dictionary<string, string>();
        foreach (PyObject key in dict.Keys())
        {
            data.Add(key.As<string>(), dict[key].As<string>());
        }
        
        return data;
    }
}