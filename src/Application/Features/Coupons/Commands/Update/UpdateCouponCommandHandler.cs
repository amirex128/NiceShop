using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Coupons.Commands.Update;

public class UpdateCouponCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<UpdateCouponCommand, Result>
{
    public async Task<Result> Handle(UpdateCouponCommand request, CancellationToken cancellationToken)
    {
        var entity = await unitOfWork.CouponRepository.GetByIdAsync(request.Id);
        Guard.Against.NotFound(request.Id, entity);

        entity.Code = request.Code ?? entity.Code;
        entity.Quantity = request.Quantity ?? entity.Quantity;
        entity.ExpiryDate = request.ExpiryDate ?? entity.ExpiryDate;
        entity.Type = request.Type ?? entity.Type;
        entity.Value = request.Value ?? entity.Value;

        var products = entity.Products?.ToList();
        unitOfWork.ProductRepository.UpdateEntityCollection(ref products, request.Products);
        entity.Products = products;

        var result = unitOfWork.CouponRepository.Update(entity);
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);

        return result ? Result.Updated() : Result.FailedUpdate();
    }
}
