using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zugo1.Controllers
{
    public class HomeController : Controller
    {
        internal static string GetConnectionString()
        {
            return $"Data Source=nandakumar;Intial Catalog=Test;User Id=sa;Password=selsel";
        }
        public ActionResult Index()
        {
            return View();
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