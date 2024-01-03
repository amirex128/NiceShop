using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class MediaRepository(ApplicationDbContext context, ILogger<Repository<Media>> logger)
    : Repository<Media>(context, logger), IMediaRepository;
