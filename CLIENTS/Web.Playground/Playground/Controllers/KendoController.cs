using Microsoft.AspNetCore.Mvc;

namespace Playground.Controllers
{
    public class KendoController : Controller
    {
        public IActionResult Grid()
        {
            return View();
        }

        public IActionResult FilterRow()
        {
            return View();
        }

        public IActionResult SignalR()
        {
            return View();
        }
    }
}