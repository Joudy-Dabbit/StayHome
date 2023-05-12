namespace Domain.Entities;

public class Customer : User
{
    private Customer() {}

    public Customer(string fullName,
        string phoneNumber, string email,
        string imageUrl, DateOnly? birthDate)
    {
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
        string deviceToken) : this(fullName, phoneNumber, email, imageUrl, birthDate)
    {
        DeviceToken = deviceToken;
    }
    
    public string? DeviceToken { get; private set; }
    
    
    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();    
    
    
    private readonly List<Address> _addresses = new();
    public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();
}