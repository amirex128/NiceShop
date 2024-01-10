using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.Coupons.Commands.Create;

public class CreateCouponCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateCouponCommand, Result>
{
    public async Task<Result> Handle(CreateCouponCommand request, CancellationToken cancellationToken)
    {
        Coupon entity = new Coupon
        {
            Code = request.Code,
            Quantity = request.Quantity,
            ExpiryDate = request.ExpiryDate,
            Type = request.Type,
            Value = request.Value,
        };

        if (request.Products is not null && request.Products.Any())
            entity.Products = await context.Products.Where(p => request.Products.Contains(p.Id)).ToListAsync();


        await context.Coupon.AddAsync(entity);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Created() : Result.FailedCreate();
    }
}
