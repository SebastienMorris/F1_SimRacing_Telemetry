using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimRacing_Telemetry_Interface.ViewModel;

public class UIDataManager : INotifyPropertyChanged
{
    private UIDataManager() {}
    
    private static UIDataManager _instance;
    public static UIDataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIDataManager();
            }
            return _instance;
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    
}
