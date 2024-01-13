using NiceShop.Application.Common.Models;

namespace NiceShop.Application.Features.ProductReviews.Commands.Delete;

public record DeleteProductReviewCommand(int Id) : IRequest<Result>;
