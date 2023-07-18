using Domain.Enum;

namespace Domain.Entities;

public class Customer : User
{
    private Customer() {}

    public Customer(string fullName,
        string phoneNumber, string email,
         DateTime? birthDate, Guid cityId, Gender gender)
    {
        CityId = cityId;
        Gender = gender;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        UserName = Guid.NewGuid().ToString();
        Email = email;
    }

    public Customer(string fullName,
        string phoneNumber, string email,
        DateTime? birthDate, Guid cityId, string deviceToken, Gender gender) 
        : this(fullName, phoneNumber, email, birthDate, cityId, gender)
    {
        DeviceToken = deviceToken;
    }
    
    public string? DeviceToken { get; private set; }
    public Gender Gender { get; private set; }

    public Guid CityId { get; private set; }
    public City City { get; private set; }
    
    
    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();    
    
    
    private readonly List<Address> _addresses = new();
    public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();
    
    public void AddAddress(string name, Guid areaId,
        string houseNumber, string street, 
        string? additional, string floor)
    {
        var address = new Address(Id,houseNumber, street, additional, areaId, name, floor);
        _addresses.Add(address);
    }
    
    public void Modify(string fullName,
        DateTime? birthDate, string email, 
        Guid cityId, string phoneNumber, Gender gender)
    {
        CityId = cityId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        Email = email;
        Gender = gender;
    }

    public ShippingOrder AddShippingOrder(double coast, double? weight,
        Guid? shopId, DateTime? scheduleDate,
        double deliveryCoast, string? note,
        Guid destinationId, Guid? sourceId)
    {
        var order = new ShippingOrder(coast, weight, 
            shopId, scheduleDate,
            deliveryCoast, note,
            destinationId, sourceId, Id);
        return order;
    }
}