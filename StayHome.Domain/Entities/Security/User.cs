using EasyRefreshToken.Abstractions;
using Microsoft.AspNetCore.Identity;
using Neptunee.BaseCleanArchitecture.BaseEntity;

namespace Domain.Entities;

public class User : BaseAggregateIdentityUser<Guid>, IUser<Guid>
{
    public User()
    {
        Id = Guid.NewGuid();
        UserName = Guid.NewGuid().ToString();
    }
    
    public string FullName { get; set; }
    public DateTime? BirthDate { get; set; }
    public DateTimeOffset? DateBlocked { get; set; }
}