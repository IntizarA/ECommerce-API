using ECommerce.Domain.Entities.Common;

namespace ECommerce.Application.Abstraction.Repositories
{
    public interface IWriteRepository<T> where T : BaseEntity
    {
        bool Add(T entity);
        Task<bool> AddAsync(T entity);
        bool AddRange(List<T> range);
        Task<bool> AddRangeAsync(List<T> range);

        bool Remove(T entity);
        bool RemoveById(string id);
        bool RemoveRange(List<T> range);
        bool Update(T entity);
        int Save();
        Task<int> SaveAsync();
    }
}
