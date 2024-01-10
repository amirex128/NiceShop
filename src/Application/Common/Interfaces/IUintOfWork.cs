using NiceShop.Application.Common.Interfaces.Repositories;

namespace NiceShop.Application.Common.Interfaces;

public interface IUnitOfWork
{
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
    public IProductReviewRepository ProductReviewRepository { get; set; }
    public IProvinceRepository ProvinceRepository { get; set; }
    public IReturnRepository ReturnRepository { get; set; }
    public ISubscriptionRepository SubscriptionRepository { get; set; }
    public IUserRepository UserRepository { get; set; }
    public IWishlistRepository WishlistRepository { get; set; }
    IApplicationDbContext Context { get; }
    Task<bool> SaveChangesAsync();
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken);
}
