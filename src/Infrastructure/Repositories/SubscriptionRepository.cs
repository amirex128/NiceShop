using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class SubscriptionRepository(ApplicationDbContext context, ILogger<Repository<Subscription>> logger)
    : Repository<Subscription>(context, logger), ISubscriptionRepository;
