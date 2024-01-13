using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Common;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Products.Commands.Update;

public class UpdateProductCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateProductCommand, Result>
{
    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Products.FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name ?? entity.Name;
        entity.Description = request.Description ?? entity.Description;
        entity.Price = request.Price ?? entity.Price;
        entity.Stock = request.Stock ?? entity.Stock;
        entity.DiscountPercent = request.DiscountPercent ?? entity.DiscountPercent;
        entity.Weight = request.Weight ?? entity.Weight;
        entity.FreeSend = request.FreeSend ?? entity.FreeSend;
        entity.HasGuarantee = request.HasGuarantee ?? entity.HasGuarantee;
        entity.LongDescription = request.LongDescription ?? entity.LongDescription;
        entity.Barcode = request.Barcode ?? entity.Barcode;
        entity.Slug = request.Slug ?? entity.Slug;
        entity.SeoTags = request.SeoTags ?? entity.SeoTags;
        entity.Status = request.Status ?? entity.Status;

        if (request.Categories is not null && request.Categories.Any())
            entity.Categories = await context.Categories.Where(x => request.Categories.Contains(x.Id)).ToListAsync(cancellationToken: cancellationToken);

        if (request.ProductVariants is not null && request.ProductVariants.Any())
            entity.ProductVariants = await context.ProductVariants.Where(x => request.ProductVariants.Contains(x.Id))
                .ToListAsync(cancellationToken: cancellationToken);

        if (request.Medias is not null && request.Medias.Any())
            entity.Medias = await context.Medias.Where(x => request.Medias.Contains(x.Id)).ToListAsync(cancellationToken: cancellationToken);

        if (request.ProductAttributes is not null && request.ProductAttributes.Any())
            entity.ProductAttributes = await context.ProductAttributes
                .Where(x => request.ProductAttributes.Contains(x.Id)).ToListAsync(cancellationToken: cancellationToken);

        context.Products.Update(entity);
        var result = await context.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Updated() : Result.FailedUpdate();
    }
}
