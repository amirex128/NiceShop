using Microsoft.AspNetCore.Http;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Domain.Entities;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.Orders.Commands.Create;

public class CreateOrderCommandHandler(
    IPaymentService paymentService,
    IApplicationDbContext context,
    IIdentityService identityService,
    IHttpContextAccessor httpContextAccessor)
    : IRequestHandler<CreateOrderCommand, Result>
{
    public async Task<Result> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var basket = await context.Baskets
            .Include(x => x.BasketItems)
            .ThenInclude(x => x.Product)
            .Include(x => x.Coupon)
            .SingleOrDefaultAsync(x => x.Id == request.BasketId, cancellationToken);
        var address =
            await context.Addresses.SingleOrDefaultAsync(x => x.Id == request.AddressId,
                cancellationToken: cancellationToken);
        var order = await context.Orders.Where(x => x.BasketId == request.BasketId)
            .SingleOrDefaultAsync(cancellationToken);

        var products = basket!.BasketItems.Select(x => x.Product).ToList();
        var isFreeSend = products.All(x => x!.FreeSend);

        User user = (await identityService.GetUserAsync())!;
        if (order is null)
        {
            order = new Order();
            order.TotalQuantityPrice = basket.TotalQuantityPrice;
            order.TotalCouponPrice = basket.TotalCouponPrice;
            order.TotalTaxPrice = 0;
            order.Description = request.Description;
            order.Ip = httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            order.Basket = basket;
            order.Coupon = basket.Coupon;
            order.OrderStatus = OrderStatusEnum.WaitForPay;
            order.Address = address;
            order.TotalSendPrice = isFreeSend ? 0 : 10000;
            order.TotalPrice = basket.TotalPrice + order.TotalSendPrice + order.TotalTaxPrice;
            
            var orderItems = new List<OrderItem>();
            foreach (var basketItem in basket.BasketItems)
            {
                var orderItem = new OrderItem();
                orderItem.ProductId = basketItem.ProductId;
                orderItem.ProductVariantId = basketItem.ProductVariantId;
                orderItem.Quantity = basketItem.Quantity;
                orderItem.QuantityPrice = basketItem.QuantityPrice;
                orderItem.Price = basketItem.Price;
                orderItems.Add(orderItem);
            }

            order.OrderItems.AddRange(orderItems);
        }
        else
        {
            order.TotalQuantityPrice = basket!.TotalQuantityPrice;
            order.TotalCouponPrice = basket.TotalCouponPrice;
            order.TotalTaxPrice = 0;
            order.Description = request.Description;
            order.Ip = httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            order.Basket = basket;
            order.Coupon = basket.Coupon;
            order.OrderStatus = OrderStatusEnum.WaitForPay;
            order.Address = address;
            order.TotalSendPrice = isFreeSend ? 0 : 10000;
            order.TotalPrice = basket.TotalPrice + order.TotalSendPrice + order.TotalTaxPrice;

            var orderItems = new List<OrderItem>();
            foreach (var basketItem in basket.BasketItems)
            {
                var orderItem = new OrderItem();
                orderItem.ProductId = basketItem.ProductId;
                orderItem.ProductVariantId = basketItem.ProductVariantId;
                orderItem.Quantity = basketItem.Quantity;
                orderItem.QuantityPrice = basketItem.QuantityPrice;
                orderItem.Price = basketItem.Price;
                orderItems.Add(orderItem);
            }

            order.OrderItems.Clear();
            await context.OrderItems.Where(x => x.OrderId == order.Id).ExecuteDeleteAsync(cancellationToken);
            order.OrderItems.AddRange(orderItems);
        }

        await paymentService.RequestShepaPayment(order.TotalPrice, user.PhoneNumber!, user.Email ?? string.Empty);

        return Result.Created();
    }
}
