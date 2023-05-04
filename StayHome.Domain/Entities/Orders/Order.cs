using Domain.Entities.Main;
using Domain.Entities.Security;
using Domain.Entities.ValueObjects;

namespace Domain.Entities.Orders;

public class Order : AggregateRoot
{
    public DateTime? ScheduleDate { get; private set; }

    public AddressOrderVo? Destination { get; set; }
    public AddressOrderVo? Source { get; private set; }
     
    public double DeliveryCoast { get; set; }
    
    public Guid? EmployeeHandlerId { get; private set; }
    public Employee? EmployeeHandler { get; private set; }

    public Guid? CustomerId { get; private set; }
    public Customer? Customer { get; private set; }
    
    public Guid? DriverId { get; private set; }
    public Driver? Driver { get; private set; }
    
    public Guid? TransportationId { get; private set; }
    public Transportation? Transportation { get; private set; }
}