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
        Dictionary<string, string> dict = PythonHandler.Run_GetDataFromType("Type");
        RaceDataManager.Instance.SelectedData = dict;
    }
}