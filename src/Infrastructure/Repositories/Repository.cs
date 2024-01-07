using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NiceShop.Application.Common.Interfaces;
using NiceShop.Application.Common.Interfaces.Repositories;
using NiceShop.Domain.Common;
using NiceShop.Infrastructure.Data;

namespace NiceShop.Infrastructure.Repositories;

public abstract class Repository<T> : IRepository<T> where T : BaseEntity, new()
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

    public bool Update(T entity)
    {
        try
        {
            dbSet.Entry(entity).CurrentValues.SetValues(entity);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error updating entity");
            return false;
        }
    }

    public bool Delete(T entity)
    {
        try
        {
            dbSet.Remove(entity);
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error deleting entity");
            return false;
        }
    }

    public async Task<T?> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes)
    {
        var query = dbSet.AsNoTracking().AsQueryable();

        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }

        try
        {
            return await query.SingleOrDefaultAsync(entity => entity.Id == id);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting entity with id {Id}", id);
            return null;
        }
    }

    public async Task<List<T>> GetByIdsAsync(int[] ids)
    {
        try
        {
            return await dbSet.AsNoTracking().Where(entity => ids.Contains(entity.Id)).ToListAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error getting entity with id {Ids}", ids);
            return new List<T>();
        }
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<int> CountAsync()
    {
        return await _context.Set<T>().AsNoTracking().CountAsync();
    }

    public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
    {
        return await _context.Set<T>().AsNoTracking().AnyAsync(predicate);
    }

    public IQueryable<T> AsQueryable()
    {
        return _context.Set<T>().AsNoTracking().AsQueryable();
    }

    public void UpdateEntityCollection(ref List<T>? entityCollection, int[]? requestCollection)
    {
        if (requestCollection != null)
        {
            if (entityCollection == null || entityCollection.Count == 0)
            {
                entityCollection = requestCollection.Select(v => new T { Id = v }).ToList();
            }
            else
            {
                var currentIds = entityCollection.Select(m => m.Id).ToList();
                var idsToAdd = requestCollection.Except(currentIds).ToList();
                var idsToRemove = currentIds.Except(requestCollection).ToList();

                entityCollection.AddRange(idsToAdd.Select(id => new T { Id = id }));

                var itemsToRemove = entityCollection.Where(m => idsToRemove.Contains(m.Id)).ToList();
                entityCollection.RemoveAll(m => itemsToRemove.Contains(m));
            }
        }
    }
    
    
}
