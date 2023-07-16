using System.ComponentModel.DataAnnotations.Schema;
using Domain.Events;

namespace Domain.Entities;

public class Area : AggregateRoot
{
    private Area() { }
    
    public Area(string name, Guid cityId)
    {
        Name = name;
        CityId = cityId;
        
       AddDomainEvent(new AddAreaPriceEvent(this));
    }
    
    public string Name { get; set; }
    
    public Guid CityId { get; private set; }
    public City City { get; private set; }
    
    private readonly List<Shop> _shops = new();
    public IReadOnlyCollection<Shop> Shops => _shops.AsReadOnly();

    private readonly List<AreaPrice> _areaPrices1 = new();
    public IReadOnlyCollection<AreaPrice> AreaPrices1 => _areaPrices1.AsReadOnly();
    
    
    private readonly List<AreaPrice> _areaPrices2 = new();
    public IReadOnlyCollection<AreaPrice> AreaPrices2 => _areaPrices2.AsReadOnly();
    
    [NotMapped]
    public IEnumerable<AreaPrice> AreaPrices => AreaPrices1.Union(AreaPrices2);
    public void AddAreaPrices(List<AreaPrice> areaPrices) => _areaPrices1.AddRange(areaPrices);

    public void Modify(string name)
    {
        Name = name;
    }
}