using NiceShop.Application.Common.Models;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.ProductVariants.Commands.Create;

public record CreateProductVariantCommand : IRequest<Result>
{
    public int ProductId  { get; set; }
    public string Name  { get; set; }= "";
    public long Price  { get; set; }
    public int Stock  { get; set; }
}
