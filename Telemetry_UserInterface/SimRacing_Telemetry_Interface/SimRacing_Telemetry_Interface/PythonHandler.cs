using Python.Runtime;

namespace SimRacing_Telemetry_Interface;

static class PythonHandler
{
    private const string PythonDllPath = @"C:\Users\markm\AppData\Local\Programs\Python\Python314\python314.dll";
    private const string PythonScriptPath = @"C:\Users\markm\Documents\SoftwareProjects\F1_SimRacing_Telemetry\SimRacing_Telemetry_DataCore";
    
    public static void RunPythonFunction(string scriptName, string methodName)
    {
        Runtime.PythonDLL = PythonDllPath;
        PythonEngine.Initialize();
        using (Py.GIL())
        {
            dynamic sys = Py.Import("sys");
            sys.path.append(PythonScriptPath);
            var pythonScript = Py.Import(scriptName);
            var result = pythonScript.InvokeMethod(methodName);
            Console.WriteLine(result);
        }
    }
}