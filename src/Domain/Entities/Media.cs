namespace NiceShop.Domain.Entities;

public class Media : BaseAuditableEntity
{
    public string Path  { get; set; } = null!;
    public string FullPath  { get; set; } = null!;
    public string MimeType  { get; set; } = null!;
    public int Size  { get; set; }
    
}
