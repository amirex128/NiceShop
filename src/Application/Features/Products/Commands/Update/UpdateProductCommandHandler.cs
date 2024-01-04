using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Common;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Products.Commands.Update;

public class UpdateProductCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateProductCommand, Result>
{
    public async Task<Result> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.ProductRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, entity);

        entity.Name = request.Name ?? entity.Name;
        entity.Description = request.Description ?? entity.Description;
        entity.Price = request.Price ?? entity.Price;
        entity.Stock = request.Stock ?? entity.Stock;
        entity.Status = request.Status ?? entity.Status;

        var categories = entity.Categories?.ToList();
        var productVariants = entity.ProductVariants?.ToList();
        var medias = entity.Medias?.ToList();
        var productAttributes = entity.ProductAttributes?.ToList();
        var productReviews = entity.ProductReviews?.ToList();

        unitOfWork.CategoryRepository.UpdateEntityCollection(ref categories, request.Categories);
        unitOfWork.ProductVariantRepository.UpdateEntityCollection(ref productVariants, request.ProductVariants);
        unitOfWork.MediaRepository.UpdateEntityCollection(ref medias, request.Medias);
        unitOfWork.ProductAttributeRepository.UpdateEntityCollection(ref productAttributes, request.ProductAttributes);
        unitOfWork.ProductReviewRepository.UpdateEntityCollection(ref productReviews, request.ProductReviews);

        entity.Categories = categories;
        entity.ProductVariants = productVariants;
        entity.Medias = medias;
        entity.ProductAttributes = productAttributes;
        entity.ProductReviews = productReviews;

        var result = unitOfWork.ProductRepository.Update(entity);
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);

        return result ? Result.Updated() : Result.FailedUpdate();
    }
}
