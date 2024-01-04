using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.Coupons.Commands.Create;

public class CreateCouponCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateCouponCommand, Result>
{
    public async Task<Result> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
    {
        var result = await unitOfWork.CouponRepository.AddAsync(new Coupon
        {
            Code = request.Code,
            Quantity = request.Quantity,
            ExpiryDate = request.ExpiryDate,
            Type = request.Type,
            Value = request.Value,
            Products = request.Products?.Select(id => new Product { Id = id }).ToList()
        });
        result = result && await unitOfWork.SaveChangesAsync(cancellationToken);
        return result ? Result.Created() : Result.FailedCreate();
    }
}
