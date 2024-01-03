using System.Linq.Expressions;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface IRepository<T> where T : class
{
    public Task<T?> GetByIdAsync(int id);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task<bool> AddAsync(T entity);
    public bool Update(T entity);
    public bool Delete(T entity);
    public Task<int> CountAsync();
    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    public IQueryable<T> AsQueryable();
}
