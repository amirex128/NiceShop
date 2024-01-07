using System.Linq.Expressions;
using NiceShop.Domain.Common;
using NiceShop.Domain.Entities;

namespace NiceShop.Application.Common.Interfaces.Repositories;

public interface IRepository<T> where T : BaseEntity, new()
{
    public Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);
    public Task<List<T>> GetByIdsAsync(int[] ids);
    public Task<List<T>> GetAllAsync();
    public Task<bool> AddAsync(T entity);
    public bool Update(T entity);
    public bool Delete(T entity);
    public Task<int> CountAsync();
    public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    public IQueryable<T> AsQueryable();
    public void UpdateEntityCollection(ref List<T>? entityCollection, int[]? requestCollection);
}
