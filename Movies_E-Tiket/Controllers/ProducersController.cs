using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies_E_Tiket.Data;

namespace Movies_E_Tiket.Controllers
{
    public class ProducersController : Controller
    {
        private readonly AppDbContext _context;

        public ProducersController(AppDbContext context)
        {
            _context= context;
        }



        public async Task<IActionResult> Index()
        {

            var allProducers = await _context.Producers.ToListAsync();
            return View();
        }
    }
}
