using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Baskets.Commands.Create;
using NiceShop.Domain.Entities;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.Baskets.Commands.Update;

public class UpdateBasketCommandHandler(IApplicationDbContext context)
    : IRequestHandler<UpdateBasketCommand, Result>
{
    public async Task<Result> Handle(UpdateBasketCommand request, CancellationToken cancellationToken)
    {
        var basket = await context.Baskets
            .Include(x => x.Coupon)
            .Include(x => x.BasketItems)
            .SingleOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        Guard.Against.NotFound(request.Id, basket);

        var products = await context.Products
            .Include(x => x.ProductVariants)
            .Where(p => request.BasketItems.Select(i => i.ProductId).Contains(p.Id))
            .ToListAsync(cancellationToken);

        var basketItems = new List<BasketItem>();

        foreach (BasketItemDto item in request.BasketItems)
        {
            var product = products.Single(p => p.Id == item.ProductId);
            var oldItem = basket.BasketItems.FirstOrDefault(x => products.Select(p => p.Id).Contains(x.ProductId));
            if (oldItem is not null)
            {
                if (product.Stock + oldItem.Quantity < item.Quantity)
                    return Result.OperationFailed($"موجودی محصول" +
                                                  $" {product.Name} " +
                                                  "کافی نیست. موجودی فعلی محصول" +
                                                  $" {product.Stock} " +
                                                  "میباشد.");
                product.Stock += oldItem.Quantity;
                product.Stock -= item.Quantity;
            }
            else
            {
                if (product.Stock < item.Quantity)
                    return Result.OperationFailed($"موجودی محصول" +
                                                  $" {product.Name} " +
                                                  "کافی نیست. موجودی فعلی محصول" +
                                                  $" {product.Stock} " +
                                                  "میباشد.");
                product.Stock -= item.Quantity;
            }

            var productVariant = product?.ProductVariants?.FirstOrDefault(pv => pv.Id == item.ProductVariantId);
            long price = productVariant?.Price ?? product?.Price ?? 0;
            long quantityPrice = price * item.Quantity;

            var basketItem = new BasketItem
            {
                Quantity = item.Quantity,
                Price = price,
                QuantityPrice = quantityPrice,
                BasketId = basket.Id,
                ProductId = item.ProductId,
                ProductVariantId = item.ProductVariantId
            };

            basketItems.Add(basketItem);
            basket.RawQuantityPrice += basketItem.QuantityPrice;
        }

        if (basket.Coupon is not null)
            if (basket.Coupon.Type == CouponTypeEnum.Percentage)
                basket.TotalCouponPrice = basket.RawQuantityPrice * basket.Coupon.Value / 100;
            else
                basket.TotalCouponPrice = basket.Coupon.Value;

        basket.FinalPrice = basket.RawQuantityPrice - basket.TotalCouponPrice;
        basket.BasketItems.Clear();
        basket.BasketItems = basketItems;
        context.Baskets.Update(basket);

        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Updated().WithObject(basket) : Result.FailedUpdate();
    }
}
