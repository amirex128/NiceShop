namespace NiceShop.Domain.Entities;

public class Subscription : BaseAuditableEntity
{

    public string Email  { get; set; } = null!;
    public string FullName  { get; set; } = null!;
}
