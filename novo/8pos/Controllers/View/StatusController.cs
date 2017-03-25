using _8pos.Controllers.Utilities;
using _8pos.Controllers.ViewModel;
using _8pos.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8pos.Controllers.View
{
    public class StatusController : Controller
    {
        public ActionResult Index()
        {
            if (SessionController.userIsLogged("admin"))
            {
                return View(new StatusViewModel().get());
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }
        }

        // GET: /Associates/Create  
        public ActionResult Create()
        {

            if (SessionController.userIsLogged("admin"))
            {
                return View();
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }
           
        }

        //  
        // POST: /Associates/Create  
        [HttpPost]
        public ActionResult Create(Status status)
        {
            if (SessionController.userIsLogged("admin"))
            {
                StatusViewModel statusViewModel = new StatusViewModel();
                statusViewModel.insert(status);
                return View(status);
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }
         
        }

        // GET: /Associates/Edit/5  
        public ActionResult Edit(int id = 0)
        {
            if (SessionController.userIsLogged("admin"))
            {
                return View(new StatusViewModel().getById(id));
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }

         
        }

        //  
        // POST: /Associates/Edit/5  
        [HttpPost]
        public ActionResult Edit(int id, Status status)
        {
            if (SessionController.userIsLogged("admin"))
            {
                StatusViewModel statusViewModel = new StatusViewModel();
                Status statusEdit = statusViewModel.getById(id);
                statusEdit.Type = status.Type;
                statusViewModel.update(statusEdit);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }
          
        }



        public ActionResult Details(int id = 0)
        {
            if (SessionController.userIsLogged("admin"))
            {
                return View(new StatusViewModel().getById(id));
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }
          
        }


        //  
        // GET: /Associates/Delete/5  
        public ActionResult Delete(int id = 0)
        {

            if (SessionController.userIsLogged("admin"))
            {
                return View(new StatusViewModel().getById(id));
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }

        }

        //  
        // POST: /Associates/Delete/5  
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            if (SessionController.userIsLogged("admin"))
            {
                new StatusViewModel().delete(new StatusViewModel().getById(id));
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }
           
        }
    }
}