using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class BasketRepository(ApplicationDbContext context, ILogger<Repository<Basket>> logger)
    : Repository<Basket>(context, logger), IBasketRepository;
