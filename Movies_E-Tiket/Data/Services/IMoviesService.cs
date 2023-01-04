using Movies_E_Tiket.Data.Base;
using Movies_E_Tiket.Data.ViewModels;
using Movies_E_Tiket.Models;

namespace Movies_E_Tiket.Data.Services
{
   /* public interface IMoviesService : IEntityBaseRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }*/

      public interface IMoviesService
      {

        Task<Movie> GetMovieByIdAsync(int id);
          Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
          Task AddNewMovieAsync(NewMovieVM data);
          Task UpdateMovieAsync(NewMovieVM data);
    }
}
