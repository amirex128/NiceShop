using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class AddressRepository(ApplicationDbContext context, ILogger<Repository<Address>> logger)
    : Repository<Address>(context, logger), IAddressRepository;
