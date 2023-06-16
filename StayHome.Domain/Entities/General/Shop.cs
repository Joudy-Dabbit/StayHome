namespace Domain.Entities;

public class Shop : AggregateRoot
{
    private Shop(){}
    
    public Shop(string name,string imageUrl,
        Guid categoryId, Guid areaId)
    {
        CategoryId = categoryId;
        AreaId = areaId;
        Name = name;
        ImageUrl = imageUrl;
    }
    
    public string Name { get; private set; }
    public string ImageUrl { get; set; }
    
    public Guid CategoryId { get; private set; }
    public Category Category { get; private set; }

    public Guid AreaId { get; private set; }
    public Area Area { get; private set; }
    

    private readonly List<Product> _products = new();
    public IReadOnlyCollection<Product> Products => _products.AsReadOnly();  
    
    
    private readonly List<WorkTime> _workTimes = new();
    public IReadOnlyCollection<WorkTime> WorkTimes => _workTimes.AsReadOnly();
    

    public void AddWorkTime(DayOfWeek daysOfWeek, TimeSpan startTime, TimeSpan endTime)
    {
        _workTimes.Add(new (daysOfWeek, endTime, startTime, Id));
    }
    public void ClearWorkTime()
    {
        _workTimes.Clear();
    }
    
    public Product AddProduct(string name, string imagUrl, double cost)
     { 
         var product = new Product(name, imagUrl, cost, Id);
         _products.Add(product);
         return product;
     }
        
    public bool IsOnline => 
        WorkTimes.Any(wt => wt.DayOfWeek == DateTime.Now.DayOfWeek  &&
                           ( wt.StartTime <= DateTime.Now.TimeOfDay 
                            && DateTime.Now.TimeOfDay <= wt.EndTime));
    
    public void Modify(string name,string imageUrl,
        Guid categoryId, Guid areaId)
    {
        CategoryId = categoryId;
        AreaId = areaId;
        Name = name;
        ImageUrl = imageUrl;
    }
}