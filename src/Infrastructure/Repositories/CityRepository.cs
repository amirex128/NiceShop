using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class CityRepository(ApplicationDbContext context, ILogger<Repository<City>> logger)
    : Repository<City>(context, logger), ICityRepository;
