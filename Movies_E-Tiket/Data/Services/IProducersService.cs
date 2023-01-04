using Movies_E_Tiket.Data.Base;
using Movies_E_Tiket.Models;

namespace Movies_E_Tiket.Data.Services
{


    public interface IProducersService
    {
        Task<IEnumerable<Producer>> GetAllAsync();

        Task<Producer> GetByIdAsync(int id);

        Task AddAsync(Producer producer);

        Task<Producer> UpdateAsync(int id, Producer newProducer);

        Task DeleteAsync(int id);

    }





}
