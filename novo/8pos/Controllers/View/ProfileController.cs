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
    public class ProfileController : Controller
    {
       
        public ActionResult Index()
        {
            if (SessionController.userIsLogged("admin"))
            {
                return View(new ProfileViewModel().get());
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
        public ActionResult Create(Profile profile)
        {
            if (SessionController.userIsLogged("admin"))
            {
                ProfileViewModel profileViewModel = new ProfileViewModel();
                profileViewModel.insert(profile);
                return View(profile);
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
                return View(new ProfileViewModel().getById(id));
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }

         
        }

        //  
        // POST: /Associates/Edit/5  
        [HttpPost]
        public ActionResult Edit(int id, Profile profile)
        {
            if (SessionController.userIsLogged("admin"))
            {
                ProfileViewModel profileViewModel = new ProfileViewModel();
                Profile profileEdit = profileViewModel.getById(id);
                profileEdit.Type = profile.Type;
                profileViewModel.update(profileEdit);
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
                return View(new ProfileViewModel().getById(id));
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
                return View(new ProfileViewModel().getById(id));
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
                new ProfileViewModel().delete(new ProfileViewModel().getById(id));
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }
        }
    }
}