namespace Domain.Entities;

public class Customer : User
{
    private Customer() {}

    public Customer(string firstName, string lastName,
        string phoneNumber, DateOnly? birthDate, string email,
        string imageUrl)
    {
        FirstName = firstName;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        UserName = Guid.NewGuid().ToString();
        ImageUrl = imageUrl;
        Email = email;
    }
    public string? DeviceToken { get; private set; }
    
    
    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();    
    
    
    private readonly List<Address> _addresses = new();
    public IReadOnlyCollection<Address> Addresses => _addresses.AsReadOnly();
}