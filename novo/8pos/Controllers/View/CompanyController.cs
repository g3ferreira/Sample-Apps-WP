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
    public class CompanyController : Controller
    {
        public static Company companySession = new Company();

        public ActionResult Index()
        {
            return View(new CompanyViewModel().get());
        }


        //  
        // GET: /Associates/Create  
        public ActionResult Create()
        {
            List<Industry> listIndustry =( List < Industry >) new IndustryViewModel().get();
            Company company = new Company();
            company.Industries = listIndustry;
            return View(company);
        }

        //  
        // POST: /Associates/Create  
        [HttpPost]
        public ActionResult Create(Company company)
        {
            //CompanyViewModel companyViewModel = new CompanyViewModel();
            //companyViewModel.createCompany(company);
            //companySession = company;
            return View(company);

        }

        [HttpPost]
        public ActionResult SetCompanySession(Company company)
        {
            //companySession = company;
            //CompanyViewModel companyViewModel = new CompanyViewModel();
            // companyViewModel.createCompany(company);
            //companySession = comp/Viewany;
            return RedirectToAction("CreateLayout","Layout", company);

        }


        // GET: /Associates/Edit/5  
        public ActionResult Edit(int id = 0)
        {
            return View(new CompanyViewModel().getById(id));
        }

        //  
        // POST: /Associates/Edit/5  
        [HttpPost]
        public ActionResult Edit(int id, Company company)
        {
            CompanyViewModel companyViewModel = new CompanyViewModel();
            Company companyEdit = companyViewModel.getById(id);
            companyEdit.About = company.About;
            companyEdit.Address = company.Address;
            companyEdit.CompanyName = company.CompanyName;
            companyEdit.Country = company.Country;
            companyEdit.Email = company.Email;
            companyViewModel.update(companyEdit);
            return RedirectToAction("Index");
        }



        public ActionResult Details(int id = 0)
        {
            return View(new CompanyViewModel().getById(id));
        }


        //  
        // GET: /Associates/Delete/5  
        public ActionResult Delete(int id = 0)
        {
            Company company = new CompanyViewModel().getById(id);
            return View(company);
        }

        //  
        // POST: /Associates/Delete/5  
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            new CompanyViewModel().delete(new CompanyViewModel().getById(id));
            return RedirectToAction("Index");
        }
    }
}