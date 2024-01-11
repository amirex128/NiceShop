using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.Baskets.Commands.Create;

public class CreateBasketCommandHandler(IApplicationDbContext context)
    : IRequestHandler<CreateBasketCommand, Result>
{
    public async Task<Result> Handle(CreateBasketCommand request, CancellationToken cancellationToken)
    {
        //TODO after 30 min we must get all basket and check if user not payed we must delete basket and add stock to products to coupon
        var products = await context.Products
            .Include(p => p.ProductVariants)
            .Where(x => request.BasketItems.Select(b => b.ProductId).Contains(x.Id))
            .ToListAsync(cancellationToken);

        var basket = new Basket();

        foreach (BasketItemDto item in request.BasketItems)
        {
            var product = products.Single(x => x.Id == item.ProductId);
            if (product.Stock < item.Quantity)
                return Result.OperationFailed($"موجودی محصول" +
                                              $" {product.Name} " +
                                              "کافی نیست. موجودی فعلی محصول" +
                                              $" {product.Stock} " +
                                              "میباشد.");

            product.Stock -= item.Quantity;

            var productVariant = product.ProductVariants?.SingleOrDefault(x => x.Id == item.ProductVariantId);
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
            basket.BasketItems.Add(basketItem);
            basket.RawQuantityPrice += basketItem.QuantityPrice;
        }


        basket.FinalPrice = basket.RawQuantityPrice - basket.TotalCouponPrice;

        await context.Baskets.AddAsync(basket, cancellationToken);
        var result = await context.SaveChangesAsync(cancellationToken);
        return result > 0 ? Result.Created().WithObject(basket) : Result.FailedCreate();
    }
}
