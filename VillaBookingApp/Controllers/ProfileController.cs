using Microsoft.AspNetCore.Mvc;

namespace VillaBookingApp.Web.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
