namespace Domain.Entities;

public class Driver : User
{
    private Driver() { }

    public string? DeviceToken { get; private set; }
}