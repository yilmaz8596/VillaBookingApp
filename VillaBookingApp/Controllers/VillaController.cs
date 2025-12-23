using Microsoft.AspNetCore.Mvc;

namespace VillaBookingApp.Web.Controllers
{
    public class VillaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
