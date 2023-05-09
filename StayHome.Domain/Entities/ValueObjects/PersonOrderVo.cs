using Neptunee.BaseCleanArchitecture.BaseEntity;

namespace Domain.Entities;

public record PersonOrderVo
{
    private PersonOrderVo(){}
    public PersonOrderVo(string fullName, string email,
        string? phoneNumber, string? telephone)
    {
        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        Telephone = telephone;
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string? PhoneNumber { get; private set; }
    public string? Telephone { get; private set; }
}