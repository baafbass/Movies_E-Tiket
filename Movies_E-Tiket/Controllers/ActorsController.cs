using Microsoft.AspNetCore.Mvc;
using Movies_E_Tiket.Data;

namespace Movies_E_Tiket.Controllers
{
    public class ActorsController : Controller
    {
        private readonly AppDbContext _context;

        public ActorsController(AppDbContext context)
        {
            _context = context; 
        }

        public IActionResult Index()
        {

            var data= _context.Actors.ToList();

            return View();
        }
    }
}
