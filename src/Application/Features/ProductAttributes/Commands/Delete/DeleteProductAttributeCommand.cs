using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.ProductAttributes.Commands.Delete;

public record DeleteProductAttributeCommand(int Id) : IRequest<Result>;
