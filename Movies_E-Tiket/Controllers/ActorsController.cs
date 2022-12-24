using Microsoft.AspNetCore.Mvc;
using Movies_E_Tiket.Data;
using Movies_E_Tiket.Data.Services;

namespace Movies_E_Tiket.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service; 
        }

        public async Task<IActionResult> Index()
        {

            var data= await _service.GetAll();

            return View(data);
        }
    }
}
