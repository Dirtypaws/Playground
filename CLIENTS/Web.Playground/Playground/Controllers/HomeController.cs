using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Playground.Models;

namespace Playground.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main()
        {
            var model = new[]
            {
                new Example
                {
                    Title = "Bootstrap",
                    Group = "bootstrap",
                    Description = "Demonstrates most controls from twitter bootstrap",
                    IconClasses = new[] {"fa-square-o fa-stack-2x", "fa-twitter fa-stack-1x"},
                    Route = "#bootstrap"
                },
                new Example
                {
                    Title = "Kendo Grid",
                    Group = "kendo",
                    Description = "A simple example of a Kendo Grid using Ajax",
                    IconClasses = new[] {"fa-th"},
                    Route = "#kendo/grid"
                },
                new Example
                {
                    Title = "Kendo Filter Row",
                    Group = "kendo",
                    Description = "An example of the Kendo filter row",
                    IconClasses = new[] {"fa-filter"},
                    Route = "#kendo/filterRow"
                },
                new Example
                {
                    Title = "Kendo SignalR",
                    Group = "kendo",
                    Description = "An example of a Kendo Grid using a SignalR data source",
                    IconClasses = new[] {"fa-wifi"},
                    Route = "#kendo/signalR"
                }
            };

            return View(model);
        }
    }
}