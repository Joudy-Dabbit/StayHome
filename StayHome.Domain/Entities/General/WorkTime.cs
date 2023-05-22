using System.ComponentModel.DataAnnotations.Schema;
using Neptunee.BaseCleanArchitecture.BaseEntity;
using Newtonsoft.Json;

namespace Domain.Entities;

public class WorkTime : AggregateRoot
{
    private WorkTime() {}
    
    public WorkTime(List<DayOfWeek> daysOfWeek, List<Time> times)
    {
        DaysOfWeek = daysOfWeek;
        Times = times;
    }
    private string days { get; set; }

    [NotMapped]
    public List<DayOfWeek> DaysOfWeek
    {
        get
        {
            days ??= "";
            return days.Split(",").Select(day => int.Parse(day))
                .Cast<DayOfWeek>().ToList();
        }
        set
        {
            value ??= new List<DayOfWeek>();
            days = string.Join(",", value.Select(day => (int)day));
        }
    }
    
    [Column("times")]
    private string _times { get; set; }

    [NotMapped]
    public List<Time> Times
    {
        get
        {
            if (_times is null) return new List<Time>();

            return JsonConvert.DeserializeObject<List<Time>>(_times) ?? new List<Time>();
        }
        set
        {
            _times = JsonConvert.SerializeObject(value);
        }
    }    
    
    public Guid ShopId { get; private set; }
    public Shop Shop { get; private set; }
}

public record Time
{
    private Time(){}
    
    public Time(TimeSpan startTime, TimeSpan endTime)
    {
        StartTime = startTime;
        EndTime = endTime;
    }

    public TimeSpan StartTime { get; private set; } 
    public TimeSpan EndTime { get; private set; }
}