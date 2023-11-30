
namespace NiceShop.Domain.Entities;

public class Province : BaseEntity
{

    public string Name  { get; set; } = null!;
    public string Slug  { get; set; } = null!;
    public StatusEnum Status { get; set; } =StatusEnum.Active;
    public ICollection<City> Cities  { get; set; } = null!;
}
