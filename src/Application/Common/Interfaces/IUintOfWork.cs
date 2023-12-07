namespace NiceShop.Application.Common.Interfaces;

public interface IUintOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    
}
