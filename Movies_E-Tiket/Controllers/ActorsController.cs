using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Movies_E_Tiket.Data;
using Movies_E_Tiket.Data.Services;
using Movies_E_Tiket.Data.Static;
using Movies_E_Tiket.Models;
using System.Data;

namespace Movies_E_Tiket.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ActorsController : Controller
    {
        private readonly IActorsService _service;

        public ActorsController(IActorsService service)
        {
            _service = service; 
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data= await _service.GetAllAsync();

            return View(data);
        }

        //Get: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
               await _service.AddAsync(actor);

                return RedirectToAction(nameof(Index));

            }
            return View(actor);
        }

        //Get: Actors/Details/1


        public async Task<IActionResult> Details(int id)
        {

            var actorDetails = await _service.GetByIdAsync(id);

            if(actorDetails== null) 
            { 
              return View("NotFound");
            }

            return View(actorDetails);
        }

        //Get: Actors/Edit
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null)
            {
                return View("NotFound");
            }

            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,FullName,ProfilePictureURL,Bio")] Actor actor)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(id,actor);

                return RedirectToAction(nameof(Index));

            }
            return View(actor);
        }

        //Get: Actors/Edit
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null)
            {
                return View("NotFound");
            }

            return View(actorDetails);
        }

        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);

            if (actorDetails == null)
            {
                return View("NotFound");
            }
            await _service.DeleteAsync(id); 
           return RedirectToAction(nameof(Index));
        }

    }
}
