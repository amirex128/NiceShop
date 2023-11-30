namespace NiceShop.Domain.Entities;

public class OTP : BaseAuditableEntity
{
    public required string UserId { get; set; }
    public User User { get; set; } = null!;
    
    public required string Code { get; set; }
    public bool IsUsed { get; set; }
}
