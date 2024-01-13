using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Products.Commands.Create;

public class CreateProductCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateProductCommand, Result>
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
            DiscountPercent=request.DiscountPercent,
            Weight=request.Weight,
            FreeSend=request.FreeSend,
            HasGuarantee=request.HasGuarantee,
            LongDescription=request.LongDescription,
            Barcode=request.Barcode,
            Slug=request.Slug,
            SeoTags=request.SeoTags,
        };

        if (request.Categories is not null && request.Categories.Any())
            product.Categories = await context.Categories.Where(x => request.Categories.Contains(x.Id)).ToListAsync();
        
        if (request.ProductVariants is not null && request.ProductVariants.Any())
            product.ProductVariants = await context.ProductVariants.Where(x => request.ProductVariants.Contains(x.Id)).ToListAsync();
        
        if (request.Medias is not null && request.Medias.Any())
            product.Medias = await context.Medias.Where(x => request.Medias.Contains(x.Id)).ToListAsync();
        
        if (request.ProductAttributes is not null && request.ProductAttributes.Any())
            product.ProductAttributes = await context.ProductAttributes.Where(x => request.ProductAttributes.Contains(x.Id)).ToListAsync();
        
        await context.Products.AddAsync(product);
        var result = await context.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Created() : Result.FailedCreate();
    }
}
