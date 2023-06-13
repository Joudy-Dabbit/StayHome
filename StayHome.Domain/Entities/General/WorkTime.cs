using System.ComponentModel.DataAnnotations.Schema;
using Neptunee.BaseCleanArchitecture.BaseEntity;
using Newtonsoft.Json;

namespace Domain.Entities;

public class WorkTime : AggregateRoot
{
    private WorkTime() { }
    
    public WorkTime(DayOfWeek dayOfWeek, 
        TimeSpan endTime, TimeSpan startTime, Guid shopId)
    {
        DayOfWeek = dayOfWeek;
        EndTime = endTime;
        StartTime = startTime;
        ShopId = shopId;
    }

    public TimeSpan StartTime { get; private set; } 
    public TimeSpan EndTime { get; private set; }
    public DayOfWeek DayOfWeek { get; private set; }
    
    public Guid ShopId { get; private set; }
    public Shop Shop { get; private set; }
}
