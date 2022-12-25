using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movies_E_Tiket.Data;
using Movies_E_Tiket.Data.Services;
using Movies_E_Tiket.Data.Static;
using Movies_E_Tiket.Data.ViewModels;
using System.Data;

namespace Movies_E_Tiket.Controllers
{
    /*
        [Authorize(Roles = UserRoles.Admin)]
        public class MoviesController : Controller
        {
            private readonly IMoviesService _service;

            public MoviesController(IMoviesService service)
            {
                _service = service;
            }

            [AllowAnonymous]
            public async Task<IActionResult> Index()
            {
               // var allMovies = await _service.GetAllAsync(n => n.Producer);
               // return View(allMovies);
            }

            [AllowAnonymous]
            public async Task<IActionResult> Filter(string searchString)
            {
               // var allMovies = await _service.GetAllAsync(n => n.Producer);

                if (!string.IsNullOrEmpty(searchString))
                {
                    //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                    var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                    return View("Index", filteredResultNew);
                }

                return View("Index", allMovies);
            }

            //GET: Movies/Details/1
            [AllowAnonymous]
            public async Task<IActionResult> Details(int id)
            {
                var movieDetail = await _service.GetMovieByIdAsync(id);
                return View(movieDetail);
            }

            //GET: Movies/Create
            public async Task<IActionResult> Create()
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View();
            }

            [HttpPost]
            public async Task<IActionResult> Create(NewMovieVM movie)
            {
                if (!ModelState.IsValid)
                {
                    var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
                    ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                    ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                    return View(movie);
                }

                await _service.AddNewMovieAsync(movie);
                return RedirectToAction(nameof(Index));
            }


            //GET: Movies/Edit/1
            public async Task<IActionResult> Edit(int id)
            {
                var movieDetails = await _service.GetMovieByIdAsync(id);
                if (movieDetails == null) return View("NotFound");

                var response = new NewMovieVM()
                {
                    Id = movieDetails.Id,
                    Name = movieDetails.Name,
                    Description = movieDetails.Description,
                    Price = movieDetails.Price,
                    StartDate = movieDetails.StartDate,
                    EndDate = movieDetails.EndDate,
                    ImageURL = movieDetails.ImageURL,
                    MovieCategory = movieDetails.MovieCategory,
                    ProducerId = movieDetails.ProducerId,
                    ActorIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
                };

                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(response);
            }

            [HttpPost]
            public async Task<IActionResult> Edit(int id, NewMovieVM movie)
            {
                if (id != movie.Id) return View("NotFound");

                if (!ModelState.IsValid)
                {
                    var movieDropdownsData = await _service.GetNewMovieDropdownsValues();
                    ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                    ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                    return View(movie);
                }

                await _service.UpdateMovieAsync(movie);
                return RedirectToAction(nameof(Index));
            }
        }
        
    */




















   
    public class MoviesController : Controller
      {
          private readonly AppDbContext _context;

          public MoviesController(AppDbContext context)
          {
              _context = context;
          }

          public async Task<IActionResult> Index()
          {
              var allMovies = await _context.Movies.OrderBy(n => n.Name).ToListAsync();
              return View(allMovies);
          }
      }
}
