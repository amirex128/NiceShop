using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Features.Coupons.Commands.Update;

public class UpdateCouponCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateCouponCommand, Result>
{
    public async Task<Result> Handle(UpdateCouponCommand request, CancellationToken cancellationToken)
    {
        var entity = await context.Coupon.FindAsync(request.Id);
        Guard.Against.NotFound(request.Id, entity);

        entity.Code = request.Code ?? entity.Code;
        entity.Quantity = request.Quantity ?? entity.Quantity;
        entity.ExpiryDate = request.ExpiryDate ?? entity.ExpiryDate;
        entity.Type = request.Type ?? entity.Type;
        entity.Value = request.Value ?? entity.Value;

        if (request.Products is not null && request.Products.Any())
        {
            entity.Products = await context.Products.Where(p => request.Products.Contains(p.Id)).ToListAsync();
        }
        
        context.Coupon.Update(entity);
        var result = await context.SaveChangesAsync(cancellationToken);

        return result > 0 ? Result.Updated() : Result.FailedUpdate();
    }
}
