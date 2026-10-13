using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace SimRacing_Telemetry_Interface.View.UserControls.DetailsPanel;

public partial class DetailElement : UserControl, INotifyPropertyChanged
{
    public DetailElement()
    {
        DataContext = this;
        InitializeComponent();
        
        //TODO: Properties for Title and Value
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private string _title = "Title";
    public string Title
    {
        get { return _title; }
        set { _title = value; OnPropertyChanged(); }
    }

    private string _value = "Value";
    public string Value
    {
        get { return _value; }
        set { _value = value; OnPropertyChanged(); }
    }
} 