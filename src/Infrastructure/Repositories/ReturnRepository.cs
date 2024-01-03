using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class ReturnRepository(ApplicationDbContext context, ILogger<Repository<Return>> logger)
    : Repository<Return>(context, logger), IReturnRepository;
