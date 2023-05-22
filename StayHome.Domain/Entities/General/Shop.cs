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
    
    public bool IsOnline => 
        WorkTimes.Any(wt => wt.DaysOfWeek.Contains(DateTime.Now.DayOfWeek ) &&
                            wt.Times.Any(t => t.StartTime <= DateTime.Now.TimeOfDay && DateTime.Now.TimeOfDay <= t.EndTime));

    public void Modify(string name,string imageUrl,
        Guid categoryId, Guid areaId)
    {
        CategoryId = categoryId;
        AreaId = areaId;
        Name = name;
        ImageUrl = imageUrl;
    }
}