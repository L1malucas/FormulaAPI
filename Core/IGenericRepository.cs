namespace FormulaAPI.Core;

public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T?>> All();
    Task<T> GetId(int id);
    Task<bool> Add(T entity);
    Task<bool> Update(T entity);
    Task<bool> Delete(T entity);
}