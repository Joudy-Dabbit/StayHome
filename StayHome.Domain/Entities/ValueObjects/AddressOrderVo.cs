using Microsoft.IdentityModel.Tokens;

namespace Domain.Entities;

public record AddressOrderVo 
{
    private AddressOrderVo() { }
    
    public AddressOrderVo(string houseNumber, string street, 
        string? additional, Guid areaId)
    {
        HouseNumber = houseNumber;
        Street = street;
        Additional = additional;
        AreaId = areaId;
    }
    
    public Guid AreaId { get; private set; }
    public Area Area { get; private set; }
    
    public string HouseNumber { get; private set; }
    public string Street { get; private set; } 
    public string? Additional { get; private set; }
    

    public override string ToString()
    {
        return string.Join(",",new []{ Street, Additional, HouseNumber}.Where(s => !s.IsNullOrEmpty()));
    }
}