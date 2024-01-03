using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public class WishlistRepository(ApplicationDbContext context, ILogger<Repository<Wishlist>> logger)
    : Repository<Wishlist>(context, logger), IWishlistRepository;
