namespace Domain.Entities.ValueObjects;

public class WorkTimeVo
{
    private WorkTimeVo() {}
    
    public WorkTimeVo(List<DayOfWeek> daysOfWeek, List<Time> times)
    {
        DaysOfWeek = daysOfWeek;
        Times = times;
    }
    
    public List<DayOfWeek> DaysOfWeek { get; private  set; }
    public List<Time> Times { get; private set; }
}

public class Time
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