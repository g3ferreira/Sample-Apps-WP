using _8pos.Controllers.ViewModel;
using _8pos.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8pos.Controllers.View
{
    public class ImageController : Controller
    {

        public ActionResult Index()
        {
            return View(new ImageViewModel().get());
        }
        //  
        // GET: /Associates/Create  
        public ActionResult Create()
        {
            return View();
        }

        //  
        // POST: /Associates/Create  
        [HttpPost]
        public ActionResult Create(Image image)
        {
            ImageViewModel imageViewModel = new ImageViewModel();
            image.Product = ProductController.productSession;
            //  imageViewModel.insert(image);
       //     new UtilityController().mountCompany(CompanyController.companySession, ProductController.productSession, image);
            return RedirectToAction("Create", "Product");
        }

        // GET: /Associates/Edit/5  
        public ActionResult Edit(int id = 0)
        {
            return View(new ImageViewModel().getById(id));
        }

        //  
        // POST: /Associates/Edit/5  
        [HttpPost]
        public ActionResult Edit(int id, Image image)
        {
            ImageViewModel imageViewModel = new ImageViewModel();
            Image imageEdit = imageViewModel.getById(id);
            imageEdit.AbsolutePath = image.AbsolutePath;
            imageViewModel.update(imageEdit);
            return RedirectToAction("Index");
        }

        

        [HttpPost]
        public ActionResult ImageUpload ()
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    string ser = Server.MapPath("~/Views");
                    string path = Server.MapPath("~/Client" + 2 + "/" + 3 + "/products");
               
                    if (Directory.Exists(path))
                    {
                     //   file.SaveAs(path + "/" + file.FileName);
                    }
                    else
                    {
                        Directory.CreateDirectory(path);
                        //file.SaveAs(path + "/"+ file.FileName);
                    }

                   
                }
            }

            return View();
        }

        public ActionResult Details(int id = 0)
        {
            return View(new ImageViewModel().getById(id));
        }


        //  
        // GET: /Associates/Delete/5  
        public ActionResult Delete(int id = 0)
        {
            Image industry = new ImageViewModel().getById(id);
            return View(industry);
        }

        //  
        // POST: /Associates/Delete/5  
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            new ImageViewModel().delete(new ImageViewModel().getById(id));
            return RedirectToAction("Index");
        }
    }
}