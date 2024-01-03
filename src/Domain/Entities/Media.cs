namespace NiceShop.Domain.Entities;

public class Media : BaseAuditableEntity
{
    public string? UserId { get; set; }
    public User? User { get; set; }
    public string? FileName { get; set; }
    public string? FullPath { get; set; }
    public string? RelativePath { get; set; }
    public string? Alt { get; set; }
    public string? Extension { get; set; }
    public long Size { get; set; }
}
