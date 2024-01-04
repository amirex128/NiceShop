namespace NiceShop.Domain.Entities;

public class OTP : BaseAuditableEntity
{
    
    public string Code { get; set; }= "";
    public bool IsUsed { get; set; }
}
