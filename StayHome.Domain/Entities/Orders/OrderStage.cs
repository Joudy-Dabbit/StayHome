using Domain.Enum;

namespace Domain.Entities;

public class OrderStage : AggregateRoot
{
    private OrderStage(Guid orderId)
    {
        OrderId = orderId;
    }
    
    public OrderStage(DateTime dateTime, OrderStages currentStage, Guid orderId)
    {
        DateTime = dateTime;
        CurrentStage = currentStage;
        OrderId = orderId;
    }
    public Order Order { get; private set; }
    public Guid OrderId { get; private set; }
    
    public DateTime DateTime { get; private set; }
    public OrderStages CurrentStage { get; private set; }
}