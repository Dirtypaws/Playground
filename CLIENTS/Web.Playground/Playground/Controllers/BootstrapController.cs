using Microsoft.AspNetCore.Mvc;

namespace Playground.Controllers
{
    public class BootstrapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}