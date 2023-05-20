namespace StayHome.Contracts.Shared.Addresses;

public class AddAddressRequest
{
    public string Name { get; set; }
    public Guid AreaId { get; set; }
    public string HouseNumber { get; set; }
    public string Street { get; set; }
    public string Floor { get; set; }
    public string? Additional { get; set; }
}