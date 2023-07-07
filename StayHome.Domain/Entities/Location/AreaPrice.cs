namespace Domain.Entities;

public class AreaPrice  : AggregateRoot
{
    private AreaPrice() {}
    
    public AreaPrice(Guid area1Id, Guid area2Id, int timeBetween)
    {
        Area1Id = area1Id;
        Area2Id = area2Id;
        TimeBetween = timeBetween;
        
    }

    public double Price { get; private set; }
    public int TimeBetween { get; private set; }

    public Guid Area1Id { get; private set; }
    public Area Area1 { get; private set; }

    public Guid Area2Id { get; private set; }
    public Area Area2 { get; private set; }

    public void Modify(double price, int timeBetween)
    {
        Price = price;
        TimeBetween = timeBetween;
    }
}