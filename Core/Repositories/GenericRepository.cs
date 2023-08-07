using FormulaAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FormulaAPI.Core.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ApiDbContext Context;

    private readonly DbSet<T> DbSet;

    protected readonly ILogger Logger;

    protected GenericRepository(
        ApiDbContext context,
        ILogger logger)
    {
        Context = context;
        Logger = logger;
        DbSet = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T?>> All()
    {
        return await DbSet.AsNoTracking().ToListAsync();
    }

    public virtual async Task<T?> GetId(int id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<bool> Add(T entity)
    {
        await DbSet.AddAsync(entity);
        return true;
    }

    public virtual Task<bool> Update(T entity)
    {
        DbSet.Update(entity);
        return Task.FromResult(true);
    }

    public virtual Task<bool> Delete(T entity)
    {
        DbSet.Remove(entity);
        return Task.FromResult(true);
    }
}