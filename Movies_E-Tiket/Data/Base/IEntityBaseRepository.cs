using Movies_E_Tiket.Models;

namespace Movies_E_Tiket.Data.Base
{
    public interface IEntityBaseRepository<T> where T: class,IEntityBase,new()
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task AddAsync(T enity);

        Task<T> UpdateAsync(int id, T entity);

        Task DeleteAsync(int id);
    }
}
