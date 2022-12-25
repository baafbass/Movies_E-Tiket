using Movies_E_Tiket.Data.Base;
using Movies_E_Tiket.Models;

namespace Movies_E_Tiket.Data.Services
{

   /* public interface IActorsService : IEntityBaseRepository<Actor>
    {
    }*/



      public interface IActorsService
      {
         Task<IEnumerable<Actor>> GetAllAsync();

          Task<Actor> GetByIdAsync(int id);  

          Task AddAsync(Actor actor);

          Task<Actor> UpdateAsync(int id, Actor newActor);

          Task DeleteAsync(int id);

      }
}
