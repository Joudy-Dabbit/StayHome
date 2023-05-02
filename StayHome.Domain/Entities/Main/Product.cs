namespace Domain.Entities.Main;

public class Product : AggregateRoot
{
    public Product(string name,string imageUrl, double cost)
    {
        Cost = cost;
        Name = name;
        ImageUrl = imageUrl;
    }
    public string Name { get; private set; }
    public string ImageUrl { get; set; }
    public double Cost { get; private set; }


    public void Modify(string name,string imageUrl, double cost)
    {
        Cost = cost;
        Name = name;
        ImageUrl = imageUrl;
    }
}