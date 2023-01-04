using Microsoft.EntityFrameworkCore;
using Movies_E_Tiket.Data.Base;
using Movies_E_Tiket.Data.ViewModels;
using Movies_E_Tiket.Models;

namespace Movies_E_Tiket.Data.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageURL = data.ImageURL,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerId = data.ProducerId
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }


        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies
                .Include(p => p.Producer)
                .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                .FirstOrDefaultAsync(n => n.Id == id);

            return movieDetails;
        }

        public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
        {
            var response = new NewMovieDropdownsVM()
            {
                Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
            };

            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageURL = data.ImageURL;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.ProducerId = data.ProducerId;
                await _context.SaveChangesAsync();
            }

            //Remove existing actors
            var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
            _context.Actors_Movies.RemoveRange(existingActorsDb);
            await _context.SaveChangesAsync();

            //Add Movie Actors
            foreach (var actorId in data.ActorIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
            }
            await _context.SaveChangesAsync();
        }
    }
    








    /*public class MoviesService : IMoviesService
     {
         private readonly AppDbContext _context;
         public MoviesService(AppDbContext context) 
         {
             _context = context;
         }

         public async Task AddNewMovieAsync(NewMovieVM data)
         {
             var newMovie = new Movie()
             {
                 Name = data.Name,
                 Description = data.Description,
                 Price = data.Price,
                 ImageURL = data.ImageURL,
                 StartDate = data.StartDate,
                 EndDate = data.EndDate,
                 MovieCategory = data.MovieCategory,
                 ProducerId = data.ProducerId
             };
             await _context.Movies.AddAsync(newMovie);
             await _context.SaveChangesAsync();

             //Add Movie Actors
             foreach (var actorId in data.ActorIds)
             {
                 var newActorMovie = new Actor_Movie()
                 {
                     MovieId = newMovie.Id,
                     ActorId = actorId
                 };
                 await _context.Actors_Movies.AddAsync(newActorMovie);
             }
             await _context.SaveChangesAsync();
         }

         public async Task<Movie> GetMovieByIdAsync(int id)
         {
             var movieDetails = await _context.Movies
                 .Include(p => p.Producer)
                 .Include(am => am.Actors_Movies).ThenInclude(a => a.Actor)
                 .FirstOrDefaultAsync(n => n.Id == id);

             return movieDetails;
         }

         public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
         {
             var response = new NewMovieDropdownsVM()
             {
                 Actors = await _context.Actors.OrderBy(n => n.FullName).ToListAsync(),
                 Producers = await _context.Producers.OrderBy(n => n.FullName).ToListAsync()
             };

             return response;
         }

         public async Task UpdateMovieAsync(NewMovieVM data)
         {
             var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.Id);

             if (dbMovie != null)
             {
                 dbMovie.Name = data.Name;
                 dbMovie.Description = data.Description;
                 dbMovie.Price = data.Price;
                 dbMovie.ImageURL = data.ImageURL;
                 dbMovie.StartDate = data.StartDate;
                 dbMovie.EndDate = data.EndDate;
                 dbMovie.MovieCategory = data.MovieCategory;
                 dbMovie.ProducerId = data.ProducerId;
                 await _context.SaveChangesAsync();
             }

             //Remove existing actors
             var existingActorsDb = _context.Actors_Movies.Where(n => n.MovieId == data.Id).ToList();
             _context.Actors_Movies.RemoveRange(existingActorsDb);
             await _context.SaveChangesAsync();

             //Add Movie Actors
             foreach (var actorId in data.ActorIds)
             {
                 var newActorMovie = new Actor_Movie()
                 {
                     MovieId = data.Id,
                     ActorId = actorId
                 };
                 await _context.Actors_Movies.AddAsync(newActorMovie);
             }
             await _context.SaveChangesAsync();
         }
     }*/
}
