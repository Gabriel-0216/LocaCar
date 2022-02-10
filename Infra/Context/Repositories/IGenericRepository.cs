namespace Infra.Context.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T?> Add(T entity);
    Task<bool> Remove(T entity);
    Task<T?> Update(T entity);
}