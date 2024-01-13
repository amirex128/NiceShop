using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.ProductVariants.Commands.Create;

public class CreateProductVariantCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateProductVariantCommand, Result>
{
    public async Task<Result> Handle(CreateProductVariantCommand request, CancellationToken cancellationToken)
    {
        var article = new ProductVariant
        {
            ProductId = request.ProductId, Name = request.Name, Price = request.Price, Stock = request.Stock
        };

        await context.ProductVariants.AddAsync(article, cancellationToken);
        var result = await context.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Created() : Result.FailedCreate();
    }
}
