using Microsoft.AspNetCore.Mvc;

namespace AutoOglasi.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
            => RedirectToAction("Index", "Automobili");

        public IActionResult Onama() => View();
        public IActionResult Kontakt() => View();
    }
}
