namespace StayHome.Contracts.Orders;

public class AddressOrderDto
{
    public Guid AreaId { get; set; }
    public string HouseNumber { get; set; }
    public string Street { get; set; } 
    public string? Additional { get; set; }
    public string Floor { get; set; }
}