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
