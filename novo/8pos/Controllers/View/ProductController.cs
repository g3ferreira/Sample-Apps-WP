using _8pos.Controllers.ViewModel;
using _8pos.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8pos.Controllers.View
{
    public class ProductController : Controller
    {
        public static Product productSession = new Product();

        public ActionResult Index()
        {
              
            return View(new ProductViewModel().get());
        }

        //  
        // GET: /Associates/Create  
        [ChildActionOnly]
        public ActionResult Create()
        {
            Company comapny = (Company) ViewData["company"];

           /* List<SelectListItem> listCategories = new List<SelectListItem>();
            List<Category> categories = new List<Category>();
            categories = (List<Category>)new CategoryViewModel().get();
            foreach (var category in categories)
            {
                listCategories.Add(new SelectListItem
                {
                    Text = category.Description,
                    Value = category.Category_Id.ToString()
                });
            }
            ViewBag.Categories = listCategories;*/
            return View();
        }

        //  
        // POST: /Associates/Create  
        [HttpPost]
        public ActionResult Create(Product product)
        {
            ProductViewModel ProductViewModel = new ProductViewModel();
            product.Category = new CategoryViewModel().getById(product.Category.Category_Id);
            product.Company = CompanyController.companySession;
           // ProductViewModel.insert(product);
            productSession = product;
            return  RedirectToAction("Create", "Image");
        }

        // GET: /Associates/Edit/5  
        public ActionResult Edit(int id = 0)
        {
            return View(new ProductViewModel().getById(id));
        }

        //  
        // POST: /Associates/Edit/5  
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            ProductViewModel ProductViewModel = new ProductViewModel();
            Category category = new CategoryViewModel().getById(product.Category.Category_Id);
            Product productEdit = new Product();
            productEdit.Description = product.Description;
            productEdit.Name = product.Name;
            productEdit.Price = product.Price;
            ProductViewModel.update(productEdit);
            return RedirectToAction("Index");
        }
        
        public ActionResult SetCompanySession(Company company, HttpFileCollectionBase files)
        {
            return View();
        }

        public ActionResult Details(int id = 0)
        {
            return View(new ProductViewModel().getById(id));
        }


        //  
        // GET: /Associates/Delete/5  
        public ActionResult Delete(int id = 0)
        {
            Product product = new ProductViewModel().getById(id);
            return View(product);
        }

        //  
        // POST: /Associates/Delete/5  
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            new ProductViewModel().delete(new ProductViewModel().getById(id));
            return RedirectToAction("Index");
        }


    }
}