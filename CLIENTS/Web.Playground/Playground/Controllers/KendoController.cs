using DataAccess.Playground.Dapper;
using Framework.Kendo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Playground.Controllers
{
    public class KendoController : Controller
    {
        public ActionResult Grid()
        {
            return View();
        }

        public ActionResult FilterRow()
        {
            return View();
        }
        public ActionResult SignalR()
        {
            return View();
        }

        // JSON
        [HttpGet]
        public JsonResult GetSchema(string formName)
        {
            try
            {
                var repo = new FormRepo();
                var forms = repo.GetAll();

                var form = forms.FirstOrDefault(x => x.Name == formName);
                var cols = form.JSchema.Properties.Select(x => new GridColumn(x));

                return Json(cols, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { result = ex.Message, type = "error" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetEntries(string formName)
        {
            try
            {
                return Json("success", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.TrySkipIisCustomErrors = true;
                Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                return Json(new { result = ex.Message, type = "error" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}