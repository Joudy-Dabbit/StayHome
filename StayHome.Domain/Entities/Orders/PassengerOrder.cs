namespace Domain.Entities;

public class PassengerOrder : Order
{
    private PassengerOrder() { }

    public PassengerOrder(int numberOfPassenger,
        DateTime? scheduleDate,
        double deliveryCoast, string? note,
        Guid destinationId, Guid sourceId, Guid customerId)
    {
        DestinationId = destinationId;
        SourceId = sourceId;
        NumberOfPassenger = numberOfPassenger;
        CustomerId = customerId;
        DeliveryCoast = deliveryCoast;
        Note = note;
        ScheduleDate = scheduleDate;
    }

    public int NumberOfPassenger { get; private set; }
}