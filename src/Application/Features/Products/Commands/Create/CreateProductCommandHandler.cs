using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Products.Commands.Create;

public class CreateProductCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateProductCommand, Result>
{
    public async Task<Result> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Stock = request.Stock,
            Status = request.Status,
            Categories = request.Categories?.Select(x => new Category { Id = x }).ToList(),
            ProductVariants = request.ProductVariants?.Select(x => new ProductVariant { Id = x }).ToList(),
            Medias = request.Medias?.Select(x => new Media { Id = x }).ToList(),
            ProductAttributes = request.ProductAttributes?.Select(x => new ProductAttribute { Id = x }).ToList(),
            ProductReviews = request.ProductReviews?.Select(x => new ProductReview { Id = x }).ToList()
        };
        var result = await unitOfWork.ProductRepository.AddAsync(product);
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return result? Result.Created() : Result.FailedCreate();
    }
}
