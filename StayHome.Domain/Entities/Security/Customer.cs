namespace Domain.Entities;

public class Customer : User
{
    private Customer(Guid cityId)
    {
        CityId = cityId;
    }

    public Customer(string fullName,
        string phoneNumber, string email,
        string imageUrl, DateOnly? birthDate, Guid cityId)
    {
        CityId = cityId;
        FullName = fullName;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        UserName = Guid.NewGuid().ToString();
        ImageUrl = imageUrl;
        Email = email;
    }

    public Customer(string fullName,
        string phoneNumber, string imageUrl, 
        string email, DateOnly? birthDate, 
        string deviceToken, Guid cityId) : this(fullName, phoneNumber, email, imageUrl, birthDate, cityId)
    {
        DeviceToken = deviceToken;
    }
    
    public string? DeviceToken { get; private set; }
    
    public Guid CityId { get; private set; }
    public City City { get; private set; }
    
    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();    
    
    
    private readonly List<Address> _addresses = new();
    public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();
}