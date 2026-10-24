using System.Windows.Controls;
using SimRacing_Telemetry_Interface.ViewModel;

namespace SimRacing_Telemetry_Interface.View.UserControls;

public partial class ViewportToolbar : UserControl
{
    private InterfaceCommand? _updateDataFilterCommand; 
    public InterfaceCommand UpdateDataFilterCommand
    {
        get
        {
            if (_updateDataFilterCommand == null)
            {
                _updateDataFilterCommand =
                    new InterfaceCommand(parameter => InterfaceCommandLibrary.UpdateDataFilter(parameter));
            }
            return _updateDataFilterCommand;
        }
    }
    
    
    
    public ViewportToolbar()
    {
        DataContext = RaceDataManager.Instance;
        InitializeComponent();
    }
}