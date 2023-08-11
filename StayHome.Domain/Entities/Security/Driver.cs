namespace Domain.Entities;

public class Driver : User
{
    private Driver() { }

    public Driver(string fullName,
        string phoneNumber, DateTime? birthDate,
        string email, Guid vehicleId)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        UserName = Guid.NewGuid().ToString();
        Email = email;
        VehicleId = vehicleId;
    }

    public Driver(string fullName,  
        string phoneNumber, DateTime? birthDate,
        string email, Guid vehicleId,
        string deviceToken) : this(fullName, phoneNumber, birthDate, email, vehicleId)
    {
        DeviceToken = deviceToken;  
    }
    
    public string? DeviceToken { get; private set; }
    
    public Guid VehicleId { get; private set; }    
    public Vehicle Vehicle { get; private set; }    

    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();   
    
    public void Modify(string fullName,
        string phoneNumber, DateTime? birthDate,
        string email, Guid vehicleId)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        Email = email;
        VehicleId = vehicleId;
    }
}