namespace Domain.Entities;

public class Rate : AggregateRoot
{
    private Rate() { }
    public Rate(Guid orderId, Guid driverId,
        double stars, string comment)
    {
        OrderId = orderId;
        DriverId = driverId;
        Stars = stars;
        Comment = comment;
    }
    public Guid OrderId { get; private set; }
    public Order Order { get; private set; }

    public Guid DriverId { get; private set; }
    public Driver Driver { get; private set; }

    public double Stars { get; private set; }
    public string Comment { get; private set; }

    public void Modify(double stars, string comment)
    {
        Stars = stars;
        Comment = comment;
    }
}