using Domain.Enum;

namespace Domain.Entities;

public class Order : AggregateRoot
{
    public DateTime? ScheduleDate { get; set; }
    public double DeliveryCoast { get; set; }
    public string? Note { get; set; }
    public string? Comment { get; set; }
    public int? Star { get; set; }
    
    public AddressOrder Destination { get; set; }
    public Guid DestinationId { get; set; }
    
    public AddressOrder? Source { get; set; }
    public Guid? SourceId { get; set; }
    

    public Guid? EmployeeHandlerId { get; set; }
    public Employee? EmployeeHandler { get; set; }

    public Guid CustomerId { get; set; }
    public Customer Customer { get; set; }
    
    public Guid? DriverId { get; set; }
    public Driver? Driver { get; set; }
    
    
    private readonly List<OrderStage> _stages = new();
    public IReadOnlyCollection<OrderStage> Stages => _stages.AsReadOnly();
    
    public OrderStage CurrentStage => Stages.OrderByDescending(os => os.DateTime).First();
    public string CurrentStageName => Stages.OrderByDescending(os => os.DateTime).First().CurrentStage.ToString();
    
    public void Handle(Guid driverId, Guid employeeHandlerId)
    {
        DriverId = driverId;
        EmployeeHandlerId = employeeHandlerId;
    }   
    
    public void Rate(int star, string? comment)
    {
        Star = star;
        Comment = comment;
    }   
    
    public void AddStage(OrderStages stage)
    {
        _stages.Add(new OrderStage(DateTime.Now, stage, Id));
    }
}