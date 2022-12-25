using Microsoft.EntityFrameworkCore;
using Movies_E_Tiket.Data.Base;
using Movies_E_Tiket.Models;


namespace Movies_E_Tiket.Data.Services
{
    /* public class ProducersService : EntityBaseRepository<Producer>, IProducersService
     {
         public ProducersService(AppDbContext context) : base(context)
         {
         }
     }*/


    public class ProducersService : IProducersService
    {
        private readonly AppDbContext _context;

        public ProducersService(AppDbContext context)
        {
            _context = context;
        }

        public Task AddAsync(Producer producer)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Producers.FirstOrDefaultAsync(n => n.Id == id);
            _context.Producers.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var result = await _context.Actors.ToListAsync();
            return result;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var result = await _context.Actors.FirstOrDefaultAsync(n => n.Id == id);

            return result;
        }

        public async Task<Actor> UpdateAsync(int id, Actor newActor)
        {
            _context.Update(newActor);
            await _context.SaveChangesAsync();
            return newActor;
        }

        public Task<Producer> UpdateAsync(int id, Producer newProducer)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Producer>> IProducersService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Producer> IProducersService.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }



}
