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

    public IAddressRepository AddressRepository { get; private set; }
    public IArticleRepository ArticleRepository { get; private set; }
    public ICategoryRepository CategoryRepository { get; private set; }

    public UnitOfWork(
        ApplicationDbContext context,
        ILoggerFactory loggerFactory
    )
    {
        _context = context;
        AddressRepository = new AddressRepository(_context, loggerFactory.CreateLogger<Repository<Address>>());
        ArticleRepository = new ArticleRepository(_context, loggerFactory.CreateLogger<Repository<Article>>());
        CategoryRepository = new CategoryRepository(_context, loggerFactory.CreateLogger<Repository<Category>>());
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
