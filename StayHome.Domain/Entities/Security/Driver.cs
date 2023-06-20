namespace Domain.Entities;

public class Driver : User
{
    private Driver() { }

    public Driver(string fullName,
        string phoneNumber, DateTime? birthDate ,string email)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        UserName = Guid.NewGuid().ToString();
        Email = email;
    }

    public Driver(string fullName,
        string phoneNumber, DateTime? birthDate
,
        string email, string imageUrl, 
        string deviceToken) : this(fullName, phoneNumber, birthDate, email)
    {
        DeviceToken = deviceToken;
    }
    
    public string? DeviceToken { get; private set; }
    
    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();   
}