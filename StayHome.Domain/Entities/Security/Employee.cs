using Neptunee.BaseCleanArchitecture.BaseEntity;

namespace Domain.Entities;

public class Employee : User
{
    private Employee(){}

    public Employee(string fullName,
        string phoneNumber, DateTime? birthDate, string email,
        string imageUrl)
    {
        FullName = fullName;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
        UserName = Guid.NewGuid().ToString();
        ImageUrl = imageUrl;
        Email = email;
    }
    
    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();   
}