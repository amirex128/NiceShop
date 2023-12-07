namespace NiceShop.Domain.Entities;

public class Media : BaseAuditableEntity
{
    public required string UserId { get; set; }
    public User? User { get; set; }
    public required string FileName { get; set; }
    public required string FullPath { get; set; }
    public required string RelativePath { get; set; }
    public string? Alt { get; set; }
    public required string Extension { get; set; }
    public long Size { get; set; }
}
