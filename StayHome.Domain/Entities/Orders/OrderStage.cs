using Domain.Enum;

namespace Domain.Entities;

public class OrderStage : AggregateRoot
{
    private OrderStage() { }
    
    public OrderStage(Order order, DateTime dateTime, OrderStages currentStage)
    {
        Order = order;
        DateTime = dateTime;
        CurrentStage = currentStage;
    }
    public Order Order { get; private set; }
    public Guid OrderId { get; private set; }
    
    public DateTime DateTime { get; private set; }
    public OrderStages CurrentStage { get; private set; }
}