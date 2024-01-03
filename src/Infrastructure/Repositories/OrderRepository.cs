using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class OrderRepository(ApplicationDbContext context, ILogger<Repository<Order>> logger)
    : Repository<Order>(context, logger), IOrderRepository;
