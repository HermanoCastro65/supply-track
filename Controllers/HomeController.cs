using Microsoft.AspNetCore.Mvc;

namespace SupplyTrack.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}