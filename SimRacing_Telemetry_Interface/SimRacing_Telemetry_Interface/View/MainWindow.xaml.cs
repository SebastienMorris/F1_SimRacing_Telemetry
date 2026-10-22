using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using SimRacing_Telemetry_Interface.ViewModel;

namespace SimRacing_Telemetry_Interface.View;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Dictionary<string, Dictionary<string, string>> dict = PythonHandler.Run_GetRaceData("Silverstone");
        RaceDataManager.Instance.RaceData = dict;
        
        //testing data filter selection
        RaceDataManager.Instance.SelectedDataId = "Lap";
    }
}