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
    public class IndustryController : Controller
    {

        public ActionResult Index()
        {
            if (SessionController.userIsLogged("admin"))
            {
                return View(new IndustryViewModel().get());
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
        public ActionResult Create(Industry industry)
        {
            if (SessionController.userIsLogged("admin"))
            {
                IndustryViewModel industryViewModel = new IndustryViewModel();
                industryViewModel.insert(industry);
                return View(industry);
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
                return View(new IndustryViewModel().getById(id));
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }
           
        }

        //  
        // POST: /Associates/Edit/5  
        [HttpPost]
        public ActionResult Edit(int id, Industry industry)
        {
            if (SessionController.userIsLogged("admin"))
            {
                IndustryViewModel industryViewModel = new IndustryViewModel();
                Industry industryEdit = industryViewModel.getById(id);
                industryEdit.Type = industry.Type;
                industryViewModel.update(industryEdit);
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
                return View(new IndustryViewModel().getById(id));
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
                Industry industry = new IndustryViewModel().getById(id);
                return View(industry);
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
                new IndustryViewModel().delete(new IndustryViewModel().getById(id));
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }
       
        }
    }
}