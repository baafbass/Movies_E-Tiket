using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace Movies_E_Tiket.Controllers
{
    public class UserController : Controller
    {
        private readonly IStringLocalizer<UserController> _localizer;

        public UserController(IStringLocalizer<UserController> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var nameSurnameValue = _localizer["NameSurname"];
            return View();
        }
    }
}
