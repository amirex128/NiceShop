using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class ProductRepository(ApplicationDbContext context, ILogger<Repository<Product>> logger)
    : Repository<Product>(context, logger), IProductRepository;
