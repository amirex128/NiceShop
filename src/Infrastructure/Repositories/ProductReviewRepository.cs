using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class ProductReviewRepository(ApplicationDbContext context, ILogger<Repository<ProductReview>> logger)
    : Repository<ProductReview>(context, logger), IProductReviewRepository;
