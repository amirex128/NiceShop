using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Infrastructure.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NiceShop.Domain.Entities;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure;

public sealed class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<UnitOfWork> _logger;

    public IAddressRepository AddressRepository { get; set; }
    public IArticleRepository ArticleRepository { get; set; }
    public IBasketItemRepository BasketItemRepository { get; set; }
    public IBasketRepository BasketRepository { get; set; }
    public ICategoryRepository CategoryRepository { get; set; }
    public ICityRepository CityRepository { get; set; }
    public ICouponRepository CouponRepository { get; set; }
    public IMediaRepository MediaRepository { get; set; }
    public IOrderItemRepository OrderItemRepository { get; set; }
    public IOrderRepository OrderRepository { get; set; }
    public IOtpRepository OtpRepository { get; set; }
    public IProductAttributeRepository ProductAttributeRepository { get; set; }
    public IProductRepository ProductRepository { get; set; }
    public IProductVariantRepository ProductVariantRepository { get; set; }
    public IProvinceRepository ProvinceRepository { get; set; }
    public IReturnRepository ReturnRepository { get; set; }
    public ISubscriptionRepository SubscriptionRepository { get; set; }
    public IUserRepository UserRepository { get; set; }
    public IWishlistRepository WishlistRepository { get; set; }


    public UnitOfWork(
        ApplicationDbContext context,
        ILoggerFactory loggerFactory
    )
    {
        _context = context;
        _logger = loggerFactory.CreateLogger<UnitOfWork>();
        AddressRepository = new AddressRepository(_context, loggerFactory.CreateLogger<Repository<Address>>());
        ArticleRepository = new ArticleRepository(_context, loggerFactory.CreateLogger<Repository<Article>>());
        BasketItemRepository = new BasketItemRepository(_context, loggerFactory.CreateLogger<Repository<BasketItem>>());
        BasketRepository = new BasketRepository(_context, loggerFactory.CreateLogger<Repository<Basket>>());
        CategoryRepository = new CategoryRepository(_context, loggerFactory.CreateLogger<Repository<Category>>());
        CityRepository = new CityRepository(_context, loggerFactory.CreateLogger<Repository<City>>());
        CouponRepository = new CouponRepository(_context, loggerFactory.CreateLogger<Repository<Coupon>>());
        MediaRepository = new MediaRepository(_context, loggerFactory.CreateLogger<Repository<Media>>());
        OrderItemRepository = new OrderItemRepository(_context, loggerFactory.CreateLogger<Repository<OrderItem>>());
        OrderRepository = new OrderRepository(_context, loggerFactory.CreateLogger<Repository<Order>>());
        OtpRepository = new OtpRepository(_context, loggerFactory.CreateLogger<Repository<OTP>>());
        ProductAttributeRepository =
            new ProductAttributeRepository(_context, loggerFactory.CreateLogger<Repository<ProductAttribute>>());
        ProductRepository = new ProductRepository(_context, loggerFactory.CreateLogger<Repository<Product>>());
        ProductVariantRepository =
            new ProductVariantRepository(_context, loggerFactory.CreateLogger<Repository<ProductVariant>>());
        ProvinceRepository = new ProvinceRepository(_context, loggerFactory.CreateLogger<Repository<Province>>());
        ReturnRepository = new ReturnRepository(_context, loggerFactory.CreateLogger<Repository<Return>>());
        SubscriptionRepository =
            new SubscriptionRepository(_context, loggerFactory.CreateLogger<Repository<Subscription>>());
        UserRepository = new UserRepository(_context, loggerFactory.CreateLogger<Repository<User>>());
        WishlistRepository = new WishlistRepository(_context, loggerFactory.CreateLogger<Repository<Wishlist>>());
    }

    public async Task<bool> SaveChangesAsync()
    {
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error saving changes");
            return false;
        }
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
