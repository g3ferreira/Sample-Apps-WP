using _8pos.Controllers.Model;
using _8pos.Controllers.ViewModel;
using _8pos.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8pos.Controllers.View
{
    public class LayoutController : Controller
    {    
        public ActionResult Index()
        {
            return View(new LayoutViewModel().get());
        }


        //  
        // GET: /Associates/Create  
        public ActionResult CreateLayout()
        {
            return View("Create");
        }

        //  
        // POST: /Associates/Create  
        [HttpPost]
        public ActionResult Create(Layout layout)
        {
            LayoutViewModel LayoutViewModel = new LayoutViewModel();
            CompanyController.companySession.Layout = layout;
            return RedirectToAction("Create", "Product");
        }


        // GET: /Associates/Edit/5  
        public ActionResult Edit(int id = 0)
        {
            return View(new LayoutViewModel().getById(id));
        }

        //  
        // POST: /Associates/Edit/5  
        [HttpPost]
        public ActionResult Edit(int id, Layout layout)
        {
            LayoutViewModel layoutViewModel = new LayoutViewModel();
            Layout layoutEdit = layoutViewModel.getById(id);
            layoutEdit.PathPictureBackground = layout.PathPictureBackground;
            layoutEdit.ShortDescription = layout.ShortDescription;
            layoutEdit.Slogan = layout.Slogan;
            layoutEdit.ColorPattern = layout.ColorPattern;
            layoutEdit.Theme = layout.Theme;
            layoutViewModel.update(layoutEdit);
            return RedirectToAction("Index");
        }
        

        public ActionResult Details(int id = 0)
        {
            return View(new LayoutViewModel().getById(id));
        }


        //  
        // GET: /Associates/Delete/5  
        public ActionResult Delete(int id = 0)
        {
            Layout layout = new LayoutViewModel().getById(id);
            return View(layout);
        }

        //  
        // POST: /Associates/Delete/5  
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            new LayoutViewModel().delete(new LayoutViewModel().getById(id));
            return RedirectToAction("Index");
        }
    }
}