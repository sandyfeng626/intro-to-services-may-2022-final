namespace ClassScheduleApi.Models;

public class StatusModel
{
    public string Message { get; set; } = string.Empty;
    public DateTime LastChecked { get; set; }
}