using MongoDB.Driver;

namespace MongoTest.UnitOfWork;

public interface IRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(string id);
    Task<IEnumerable<T>> GetByFilter(FilterDefinition<T> filter);
    Task<T> AddAsync(T entity);
    Task<bool> RemoveAsync(string id);
    Task<bool> UpdateAsync(string id, T entity);
}
