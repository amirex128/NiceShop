using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class UserRepository(ApplicationDbContext context, ILogger<Repository<User>> logger)
    : Repository<User>(context, logger), IUserRepository;
