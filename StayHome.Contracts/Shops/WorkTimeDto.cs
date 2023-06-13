using Domain.Entities;

namespace StayHome.Contracts.Shops;

public class WorkTimeDto
{
    public DayOfWeek DayOfWeek { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}

