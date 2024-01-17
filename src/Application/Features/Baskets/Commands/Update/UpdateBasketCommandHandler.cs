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
        basket.TotalQuantityPrice = 0;
        foreach (BasketItemDto item in request.BasketItems)
        {
            var product = products.Single(p => p.Id == item.ProductId);
            var productVariant = product.ProductVariants?.FirstOrDefault(pv => pv.Id == item.ProductVariantId);
            var oldItem = basket.BasketItems.FirstOrDefault(x => products.Select(p => p.Id).Contains(x.ProductId));

            if (productVariant is null)
                return Result.OperationFailed($"محصول" +
                                              $" {product.Name} " +
                                              "یافت نشد.");


            if (oldItem is not null)
            {
                if (productVariant.Stock + oldItem.Quantity < item.Quantity)
                    return Result.OperationFailed($"موجودی محصول" +
                                                  $" {product.Name} " +
                                                  "کافی نیست. موجودی فعلی محصول" +
                                                  $" {productVariant.Stock} " +
                                                  "میباشد.");
                productVariant.Stock += oldItem.Quantity;
                productVariant.Stock -= item.Quantity;
            }
            else
            {
                if (productVariant.Stock < item.Quantity)
                    return Result.OperationFailed($"موجودی محصول" +
                                                  $" {product.Name} " +
                                                  "کافی نیست. موجودی فعلی محصول" +
                                                  $" {productVariant.Stock} " +
                                                  "میباشد.");
                productVariant.Stock -= item.Quantity;
            }


            long price = productVariant?.Price ?? 0;
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
            basket.TotalQuantityPrice += basketItem.QuantityPrice;
        }

        if (basket.Coupon is not null)
            if (basket.Coupon.Type == CouponTypeEnum.Percentage)
                basket.TotalCouponPrice = basket.TotalQuantityPrice * basket.Coupon.Value / 100;
            else
                basket.TotalCouponPrice = basket.Coupon.Value;

        basket.TotalPrice = basket.TotalQuantityPrice - basket.TotalCouponPrice;
        basket.BasketItems.Clear();
        basket.BasketItems = basketItems;
        context.Baskets.Update(basket);

       var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Updated().WithObject(basket) : Result.FailedUpdate();
    }
}
