namespace StayHome.Contracts.Shops;

public class WorkTimeRes
{
    public string DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}