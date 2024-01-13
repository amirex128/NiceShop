using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.ProductAttributes.Commands.Create;

public class CreateProductAttributeCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateProductAttributeCommand, Result>
{
    public async Task<Result> Handle(CreateProductAttributeCommand request, CancellationToken cancellationToken)
    {

        var article = new ProductAttribute
        {
            ProductId = request.ProductId,
            Type = request.Type,
            Name = request.Name,
            Value = request.Value
        };

        await context.ProductAttributes.AddAsync(article, cancellationToken);
        var result = await context.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Created() : Result.FailedCreate();
    }
}
