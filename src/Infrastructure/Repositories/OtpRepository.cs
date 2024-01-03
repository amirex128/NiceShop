using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class OtpRepository(ApplicationDbContext context, ILogger<Repository<OTP>> logger)
    : Repository<OTP>(context, logger), IOtpRepository;
