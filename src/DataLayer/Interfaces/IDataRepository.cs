
namespace DataLayer.Interfaces
{
    public interface IDataRepository
    {}

    public interface IDataRepository<T> : IDataRepository
        where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
