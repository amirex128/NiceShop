using NiceShop.Domain.Attributes;

namespace NiceShop.Domain.Entities;

[SoftDelete]
public class City : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Slug { get; set; } = null!;
    public StatusEnum Status { get; set; } = StatusEnum.Active;

    public int ProvinceId { get; set; }
    public Province Province { get; set; } = null!;
}
