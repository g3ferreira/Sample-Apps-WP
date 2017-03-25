using _8pos.Controllers.Model;
using _8pos.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8pos.View.Controllers
{
    public class HomeController : Controller
    {

       
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateWebsite()
        {
            return View();
        }

        public ActionResult Marketplace()
        {
            return View();
        }

        public ActionResult DevelopersArea()
        {
            return View();
        }

        public ActionResult POS()
        {
            return View();
        }

        public ActionResult Ecommerce()
        {
            return View();
        }

        public ActionResult Inventory()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Features()
        {
            return new RedirectResult(Url.Action("Index") + "#features");
        }
    }
}