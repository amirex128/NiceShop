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
            .Include(x => x.Coupon)
            .SingleOrDefaultAsync(x => x.Id == request.BasketId, cancellationToken: cancellationToken);
        var address =
            await context.Addresses.SingleOrDefaultAsync(x => x.Id == request.AddressId,
                cancellationToken: cancellationToken);
        var order = await context.Orders.Where(x => x.BasketId == request.BasketId)
            .SingleOrDefaultAsync(cancellationToken);

        User user = (await identityService.GetUserAsync())!;
        if (order is null)
        {
            order = new Order();
            order.TotalQuantityPrice = basket!.TotalQuantityPrice;
            order.TotalCouponPrice = basket.TotalCouponPrice;
            order.TotalPrice = basket.TotalPrice;
            order.TotalTaxPrice = 0;
            order.TotalSendPrice = 0;
            order.Description = request.Description;
            order.Ip = httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            order.Basket = basket;
            order.OrderStatus = OrderStatusEnum.WaitForPay;
            order.Address = address;
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
            order.TotalPrice = basket.TotalPrice;
            order.TotalTaxPrice = 0;
            order.TotalSendPrice = 0;
            order.Description = request.Description;
            order.Ip = httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            order.Basket = basket;
            order.OrderStatus = OrderStatusEnum.WaitForPay;
            order.Address = address;
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

            context.OrderItems.RemoveRange(context.OrderItems.Where(x => x.OrderId == order.Id));
            order.OrderItems.Clear();
            order.OrderItems.AddRange(orderItems);
        }

        await paymentService.RequestShepaPayment(order.TotalPrice, user.PhoneNumber!, user.Email ?? string.Empty);

        return Result.Created();
    }
}
