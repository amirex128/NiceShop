namespace NiceShop.Domain.Entities;

public class OTP : BaseAuditableEntity
{
    
    public required string Code { get; set; }
    public bool IsUsed { get; set; }
}
