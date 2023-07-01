using Domain.Enum;

namespace Domain.Entities;

public class Order : AggregateRoot
{
    public DateTime? ScheduleDate { get; private set; }
    public double DeliveryCoast { get; private set; }
    public string Note { get; private set; }
    public AddressOrder? Destination { get; private set; }
    public Guid? DestinationId { get; private set; }
    
    public AddressOrder Source { get; private set; }
    public Guid SourceId { get; private set; }
    

    public Guid? EmployeeHandlerId { get; private set; }
    public Employee? EmployeeHandler { get; private set; }

    public Guid? CustomerId { get; private set; }
    public Customer? Customer { get; private set; }
    
    public Guid? DriverId { get; private set; }
    public Driver? Driver { get; private set; }
    
    public Guid? VehicleId { get; private set; }
    public Vehicle? Vehicle { get; private set; }
    
    
    private readonly List<OrderStage> _stages = new();
    public IReadOnlyCollection<OrderStage> Stages => _stages.AsReadOnly();
    
    public OrderStage CurrentStage => Stages.OrderByDescending(os => os.DateTime).First();
    public string CurrentStageName => Stages.OrderByDescending(os => os.DateTime).First().CurrentStage.ToString();
}