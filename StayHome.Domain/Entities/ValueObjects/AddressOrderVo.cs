using Microsoft.IdentityModel.Tokens;
using Neptunee.BaseCleanArchitecture.BaseEntity;

namespace Domain.Entities.ValueObjects;

public record AddressOrderVo 
{
    private AddressOrderVo(){}
    
    public AddressOrderVo(string houseNumber, string street, 
        string? additional)
    {
        HouseNumber = houseNumber;
        Street = street;
        Additional = additional;
    }
    public string HouseNumber { get; private set; }
    public string Street { get; private set; } 
    public string? Additional { get; private set; }
    

    public override string ToString()
    {
        return string.Join(",",new []{ Street, Additional, HouseNumber}.Where(s => !s.IsNullOrEmpty()));
    }
}