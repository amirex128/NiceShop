using System.Linq.Expressions;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface IRepository<T>  where T : class
{
    public Task<T?> GetByIdAsync(int id);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<bool> AddAsync(T entity);
    public Task<bool> UpdateAsync(int id,T entity);
    public Task<bool> DeleteAsync(int id);
    public Task<int> CountAsync();
    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);


}
