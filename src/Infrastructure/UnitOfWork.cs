using NiceShop.Application.Common.Interfaces;

namespace NiceShop.Infrastructure;

public sealed class UnitOfWork : IUintOfWork, IDisposable
{
    private readonly IApplicationDbContext _context;

    public UnitOfWork(IApplicationDbContext context)
    {
        _context = context;
    }

    public async void Dispose()
    {
        await _context.DisposeAsync();
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
