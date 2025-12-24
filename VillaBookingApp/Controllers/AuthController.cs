using Microsoft.AspNetCore.Mvc;

namespace VillaBookingApp.Web.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller
    {
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
