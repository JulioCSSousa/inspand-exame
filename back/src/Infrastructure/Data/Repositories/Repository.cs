using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
{
    protected readonly SqlDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public Repository(SqlDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<TEntity>();
    }

    public virtual async Task InsertAsync(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        entity.SetLastAction();
        await _dbSet.AddAsync(entity);
    }

    public virtual async Task DeleteAsync(long id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity with ID {id} not found.");

        _dbSet.Remove(entity);
    }

    public virtual async Task UpdateAsync(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        entity.SetLastAction();
        _dbSet.Update(entity);
    }

    public virtual async Task<TEntity> GetByIdAsync(long id)
    {
        var entity = await _dbSet.FirstOrDefaultAsync(p => p.Id == id);
        if (entity == null)
            throw new KeyNotFoundException($"Entity with ID {id} not found.");
        return entity;
    }

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }
}
