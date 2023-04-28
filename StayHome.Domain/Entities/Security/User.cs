using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser<Guid>
{
    public User()
    {
        Id = Guid.NewGuid();
        UserName = Guid.NewGuid().ToString();
    }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string? ImageUrl { get; set; }
    public DateOnly? BirthDate { get; set; }

    public string FullName => $"{FirstName} {LastName}";
}