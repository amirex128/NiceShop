using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class ProductVariantRepository(ApplicationDbContext context, ILogger<Repository<ProductVariant>> logger)
    : Repository<ProductVariant>(context, logger), IProductVariantRepository;
