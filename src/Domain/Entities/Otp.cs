namespace NiceShop.Domain.Entities;

public class Otp : BaseAuditableEntity
{
    
    public int Code { get; set; }
    public bool IsUsed { get; set; }
}
