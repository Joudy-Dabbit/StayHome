using Domain.Entities;

namespace StayHome.Contracts.Shops;

public class WorkTimeReq
{
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}

