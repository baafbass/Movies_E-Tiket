using Movies_E_Tiket.Models;

namespace Movies_E_Tiket.Data.Services
{
    public interface IActorsService
    {
       Task<IEnumerable<Actor>> GetAllAsync();

        Task<Actor> GetByIdAsync(int id);  

        Task AddAsync(Actor actor);

        Actor Update(int id, Actor newActor);

        void Delete(int id);

    }
}
