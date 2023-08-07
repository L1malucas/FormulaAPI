using FormulaAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace FormulaAPI.Core.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly ILogger Logger;

    protected ApiDbContext Context;

    internal DbSet<T?> DbSet;

    public GenericRepository(
        ApiDbContext context,
        ILogger logger)
    {
        Context = context;
        Logger = logger;
        DbSet = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> All()
    {
        return await DbSet.ToListAsync();
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

    public virtual async Task<bool> Update(T entity)
    {
        DbSet.Update(entity);
        return true;
    }

    public virtual async Task<bool> Delete(T entity)
    {
        DbSet.Remove(entity);
        return true;
    }
}