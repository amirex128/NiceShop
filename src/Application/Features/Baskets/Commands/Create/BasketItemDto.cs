namespace NiceShop.Application.Features.Baskets.Commands.Create;

public record BasketItemDto
{
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public int? ProductVariantId { get; set; }
}