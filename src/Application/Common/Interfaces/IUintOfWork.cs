using NiceShop.Application.Common.Interfaces.Repositories;

namespace NiceShop.Application.Common.Interfaces;

public interface IUnitOfWork
{
    IAddressRepository AddressRepository { get; }
    IArticleRepository ArticleRepository { get; }
    ICategoryRepository CategoryRepository { get; }
    Task CompleteAsync(); 
}
