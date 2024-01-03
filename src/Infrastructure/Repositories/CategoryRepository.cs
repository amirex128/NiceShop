using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class CategoryRepository(ApplicationDbContext context, ILogger<Repository<Category>> logger)
    : Repository<Category>(context, logger), ICategoryRepository;
