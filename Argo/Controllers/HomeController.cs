using Argo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Argo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ArgoContext context = new ArgoContext();
            return View(context.Trips.Take(3));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}