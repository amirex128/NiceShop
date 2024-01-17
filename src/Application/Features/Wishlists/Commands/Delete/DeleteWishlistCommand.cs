using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Wishlists.Commands.Delete;

public record DeleteWishlistCommand(int Id) : IRequest<Result>;
