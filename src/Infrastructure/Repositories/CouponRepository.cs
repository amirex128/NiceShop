using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class CouponRepository(ApplicationDbContext context, ILogger<Repository<Coupon>> logger)
    : Repository<Coupon>(context, logger), ICouponRepository;
