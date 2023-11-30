namespace NiceShop.Domain.Entities;

public class Address : BaseAuditableEntity
{
    public string Title { get; set; } = null!;
    public string AddressLine { get; set; } = null!;
    public string PostalCode { get; set; } = null!;

    public int CityId { get; set; }
    public City City { get; set; } = null!;
    public int ProvinceId { get; set; }
    public Province Province { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public User User { get; set; } = null!;
}
