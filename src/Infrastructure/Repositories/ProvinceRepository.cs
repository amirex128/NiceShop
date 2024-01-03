using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class ProvinceRepository(ApplicationDbContext context, ILogger<Repository<Province>> logger)
    : Repository<Province>(context, logger), IProvinceRepository;
