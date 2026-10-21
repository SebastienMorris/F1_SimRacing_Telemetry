using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimRacing_Telemetry_Interface.ViewModel;

public class RaceDataManager : INotifyPropertyChanged
{
    private RaceDataManager() {}
    
    /// SINGLETON ///
    private static RaceDataManager? _instance;
    public static RaceDataManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new RaceDataManager();
            }
            return _instance;
        }
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    Dictionary<string, string> _selectedData = new Dictionary<string, string>{{"Title", "Value"}};
    public Dictionary<string, string> SelectedData
    {
        get { return Instance._selectedData; }
        set {  Instance._selectedData = value; OnPropertyChanged(); }
    }
}