using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimRacing_Telemetry_Interface.ViewModel;

public class UIData : INotifyPropertyChanged
{
    private UIData() {}
    
    private static UIData _instance;
    public static UIData Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new UIData();
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
