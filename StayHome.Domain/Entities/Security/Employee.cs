using Neptunee.BaseCleanArchitecture.BaseEntity;

namespace Domain.Entities;

public class Employee : User
{
    private Employee(){}

    
    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();   
}