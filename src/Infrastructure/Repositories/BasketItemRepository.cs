using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class BasketItemRepository(ApplicationDbContext context, ILogger<Repository<BasketItem>> logger)
    : Repository<BasketItem>(context, logger), IBasketItemRepository;
