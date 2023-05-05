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
}