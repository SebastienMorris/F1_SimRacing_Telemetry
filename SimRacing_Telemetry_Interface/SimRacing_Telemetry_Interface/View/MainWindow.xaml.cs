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
       // PythonHandler.Run_GetServerAddress();
        //tbHello.Text = PythonHandler.Run_GetServerAddress().Item1;
    }
}