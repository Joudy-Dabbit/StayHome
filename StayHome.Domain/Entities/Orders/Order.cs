namespace Domain.Entities;

public class Order : AggregateRoot
{
    public DateTime? ScheduleDate { get; private set; }
    public double DeliveryCoast { get; set; }

    public AddressOrderVo? Destination { get; set; }
    public AddressOrderVo? Source { get; private set; }
    
    public Guid? EmployeeHandlerId { get; private set; }
    public Employee? EmployeeHandler { get; private set; }

    public Guid? CustomerId { get; private set; }
    public Customer? Customer { get; private set; }
    
    public Guid? DriverId { get; private set; }
    public Driver? Driver { get; private set; }
    
    public Guid? VehicleId { get; private set; }
    public Vehicle? Vehicle { get; private set; }
}