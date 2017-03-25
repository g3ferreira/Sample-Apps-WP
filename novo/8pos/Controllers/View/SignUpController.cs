using _8pos.Controllers.Model;
using _8pos.Controllers.Utilities;
using _8pos.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8pos.Controllers.View
{
    public class SignUpController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View("SignIn");
        }

        public ActionResult UserCreate(PosUser posUser)
        {

            if (ModelState.IsValid)
            {
                return new UserController().Create(posUser);
            }
            else
            {
                return View("Index", posUser);
            }
        }
        

        public ActionResult Login()
        {
            return View();
        }
    }
}