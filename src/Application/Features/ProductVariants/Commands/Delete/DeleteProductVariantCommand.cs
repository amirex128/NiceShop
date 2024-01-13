using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.ProductVariants.Commands.Delete;

public record DeleteProductVariantCommand(int Id) : IRequest<Result>;
