using System.Web.Mvc;

namespace Kendo.LESS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddPerson()
        {
            return View("modals/AddPerson");
        }

    }
}
