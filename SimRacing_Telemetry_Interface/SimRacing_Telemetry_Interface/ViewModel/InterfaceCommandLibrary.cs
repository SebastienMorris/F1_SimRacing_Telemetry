namespace SimRacing_Telemetry_Interface.ViewModel;

public static class InterfaceCommandLibrary
{
    public static void UpdateDataFilter(object? filterId)
    {
        if (filterId != null)
        {
            RaceDataManager.Instance.SelectedDataId = (string)filterId;
        }
    }
}