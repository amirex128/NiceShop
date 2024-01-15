using Microsoft.EntityFrameworkCore;
using NiceShop.Application.Common.Interfaces;
using Quartz;

namespace NiceShop.Infrastructure.Schedulers;

public class RemoveBaskets(IApplicationDbContext context) : IJob
{
    public Task Execute(IJobExecutionContext jobContext)
    {
        var baskets = context.Baskets
            .Include(x=>x.BasketItems)
            .ThenInclude(x=>x.Product)
            .Include(x=>x.BasketItems)
            .ThenInclude(x=>x.ProductVariant)
            .Include(x => x.Coupon)
            .ThenInclude(x => x!.UsedBy)
            .Where(x => x.LastModified < DateTime.Now.AddMinutes(60));
        foreach (var basket in baskets)
        {
            if (basket.Coupon != null)
            {
                basket.Coupon.Quantity++;
                basket.Coupon.UsedBy.RemoveAll(x => x.Id == basket.UserId);
            }

            foreach (var basketItem in basket.BasketItems)
            {
                basketItem.ProductVariant!.Stock += basketItem.Quantity;
            }
            
            basket.BasketItems.Clear();
            context.Baskets.Remove(basket);
        }
        
        return context.SaveChangesAsync();
    }
}
