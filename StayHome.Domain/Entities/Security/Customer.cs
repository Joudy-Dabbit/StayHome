namespace Domain.Entities;

public class Customer : User
{
    private Customer(){}
    
    public string? DeviceToken { get; private set; }
}