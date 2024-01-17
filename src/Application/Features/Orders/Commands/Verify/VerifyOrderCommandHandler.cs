using Microsoft.AspNetCore.Http;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Models;
using NiceShop.Application.Features.Orders.Commands.Verify;
using NiceShop.Domain.Entities;
using NiceShop.Domain.Enums;

namespace NiceShop.Application.Features.Orders.Commands.Verify;

public class VerifyOrderCommandHandler(
    IPaymentService paymentService,
    IApplicationDbContext context)
    : IRequestHandler<VerifyOrderCommand, Result>
{
    public async Task<Result> Handle(VerifyOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await context.Orders.FindAsync(request.OrderId);

        ShepaPaymentVerifyResult? verifyResult =
            await paymentService.VerifyShepaPayment(request.Token!, order!.TotalPrice);

        if (verifyResult is not null && verifyResult.Success)
        {
            order.OrderStatus = OrderStatusEnum.Paid;
            
            await context.Baskets.Where(x => x.Id == order.BasketId).ExecuteDeleteAsync(cancellationToken);
            await context.BasketItems.Where(x => x.BasketId == order.BasketId).ExecuteDeleteAsync(cancellationToken);

            await context.SaveChangesAsync(cancellationToken);
        }
        else
        {
            order.OrderStatus = OrderStatusEnum.WaitForTryPay;

            return Result.OperationFailed();
        }

        return Result.OperationSuccess();
    }
}
