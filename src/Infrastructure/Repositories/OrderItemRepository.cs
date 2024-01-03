using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class OrderItemRepository(ApplicationDbContext context, ILogger<Repository<OrderItem>> logger)
    : Repository<OrderItem>(context, logger), IOrderItemRepository;
