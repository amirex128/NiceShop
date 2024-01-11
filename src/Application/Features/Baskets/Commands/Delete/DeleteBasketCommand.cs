using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.Baskets.Commands.Delete;

public record DeleteBasketCommand(int Id) : IRequest<Result>;
