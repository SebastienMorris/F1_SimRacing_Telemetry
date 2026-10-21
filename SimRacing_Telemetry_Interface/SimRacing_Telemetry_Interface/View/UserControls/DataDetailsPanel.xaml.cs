using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using SimRacing_Telemetry_Interface.ViewModel;

namespace SimRacing_Telemetry_Interface.View.UserControls;

public partial class DataDetailsPanel : UserControl
{
    public DataDetailsPanel()
    {
        DataContext = RaceDataManager.Instance;
        InitializeComponent();
    }
}