using System.Windows.Controls;
using SimRacing_Telemetry_Interface.ViewModel;

namespace SimRacing_Telemetry_Interface.View.UserControls;

public partial class ViewportToolbar : UserControl
{
    public ViewportToolbar()
    {
        DataContext = RaceDataManager.Instance;
        InitializeComponent();
    }
}