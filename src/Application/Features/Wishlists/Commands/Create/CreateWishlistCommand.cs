using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Wishlists.Commands.Create;

public record CreateWishlistCommand : IRequest<Result>
{
    public int ProductId { get; set; }
}
