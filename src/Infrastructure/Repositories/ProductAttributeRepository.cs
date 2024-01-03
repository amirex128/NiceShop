using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class ProductAttributeRepository(ApplicationDbContext context, ILogger<Repository<ProductAttribute>> logger)
    : Repository<ProductAttribute>(context, logger), IProductAttributeRepository;
