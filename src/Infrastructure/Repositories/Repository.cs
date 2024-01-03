using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public abstract class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private DbSet<T> dbSet;
    private readonly ILogger<Repository<T>> _logger;

    public Repository(ApplicationDbContext context, ILogger<Repository<T>> logger)
    {
        _context = context;
        this.dbSet = _context.Set<T>();
        _logger = logger;
    }

    public async Task<bool> AddAsync(T entity)
    {
        try
        {
            await dbSet.AddAsync(entity);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error adding entity");
            return false;
        }
    }

    public async Task<bool> UpdateAsync(int id, T entity)
    {
        try
        {
            var entityToUpdate = await dbSet.FindAsync(id);
            if (entityToUpdate != null)
            {
                dbSet.Entry(entityToUpdate).CurrentValues.SetValues(entity);
                return true;
            }
            else
            {
                _logger.LogWarning("Entity with id {Id} not found for update", id);
                return false;
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error updating entity with id {Id}", id);
            return false;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null)
            {
                dbSet.Remove(entity);
                return true;
            }
            else
            {
                _logger.LogWarning("Entity with id {Id} not found for deletion", id);
                return false;
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error deleting entity with id {Id}", id);
            return false;
        }
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        try
        {
            return await dbSet.FindAsync(id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting entity with id {Id}", id);
            return null;
        }
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _context.Set<T>().CountAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().AnyAsync(predicate);
    }

    public IQueryable<T> AsQueryable()
    {
        return _context.Set<T>().AsQueryable();
    }
}
