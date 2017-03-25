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
    public class CategoryController : Controller
    {

        public ActionResult Index()
        {
            if (SessionController.userIsLogged("admin"))
            {
                return View(new CategoryViewModel().get());
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }
        }


        //  
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
        public ActionResult Create(Category category)
        {
            if (SessionController.userIsLogged("admin"))
            {

                CategoryViewModel CategoryViewModel = new CategoryViewModel();
                CategoryViewModel.insert(category);
                return View(category);
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

                return View(new CategoryViewModel().getById(id));
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }


        }

        //  
        // POST: /Associates/Edit/5  
        [HttpPost]
        public ActionResult Edit(int id, Category category)
        {
            if (SessionController.userIsLogged("admin"))
            {
                CategoryViewModel categoryViewModel = new CategoryViewModel();
                Category categoryEdit = categoryViewModel.getById(id);
                categoryEdit.Description = category.Description;
                categoryViewModel.update(categoryEdit);
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

                return View(new CategoryViewModel().getById(id));
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

                Category category = new CategoryViewModel().getById(id);
                return View(category);
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

                new CategoryViewModel().delete(new CategoryViewModel().getById(id));
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }
        }
    }
}