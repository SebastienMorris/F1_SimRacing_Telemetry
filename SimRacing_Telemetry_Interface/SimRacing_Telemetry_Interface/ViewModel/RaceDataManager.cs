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
    
    private Dictionary<string, Dictionary<string, string>> _raceData;
    public Dictionary<string, Dictionary<string, string>> RaceData
    {
        get { return Instance._raceData; }
        set {Instance._raceData = value; OnPropertyChanged(); }
    }
    
    Dictionary<string, string> _selectedData = new Dictionary<string, string>{{"Title", "Value"}};
    public Dictionary<string, string> SelectedData
    {
        get { return Instance._selectedData; }
        set {  Instance._selectedData = value; OnPropertyChanged(); }
    }

    private string _selectedDataId;
    public string SelectedDataId
    {
        get { return Instance._selectedDataId;  }
        set { 
            Instance._selectedDataId  = value; 
            OnPropertyChanged();
            
            if (Instance.RaceData.ContainsKey(value)) { Instance.SelectedData = Instance.RaceData[value]; }
        }
    }
}