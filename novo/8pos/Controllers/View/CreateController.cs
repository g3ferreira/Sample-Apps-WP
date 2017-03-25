using _8pos.Controllers.Model;
using _8pos.Controllers.Utilities;
using _8pos.Controllers.ViewModel;
using _8pos.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _8pos.Controllers
{
    public class CreateController : Controller
    {
        public void SetCompanySession(Company company)
        {
            Company.CompanySession = company;
        }


        public ActionResult Index()
        {
            List<Industry> listIndustry = (List<Industry>)new IndustryViewModel().get();
            Company.CompanySession.Industries = new List<Industry>();
            Company.CompanySession.Industries = listIndustry;
            return View(Company.CompanySession);
        }

        public ActionResult IndexCreate(int userId)
        {
            ViewBag.Active = "active";
            List<Industry> listIndustry;
            if (SessionController.userIsLogged("default"))
            {
                if (SessionController.getUserSession().Companies.Count == 0)
                {
                    listIndustry = (List<Industry>)new IndustryViewModel().get();
                    Company.CompanySession = new Company();
                    Company.CompanySession.Industries = new List<Industry>();
                    Company.CompanySession.Industries = listIndustry;
                    Company.CompanySession.SelectedView = "1";
                    Company.CompanySession.PosUser = SessionController.getUserSession();
                    return View("Index", Company.CompanySession);
                }
                else
                {
                    return RedirectToAction("SignIn", "User", null);
                }
            }
            else if (SessionController.userIsLogged("admin"))
            {

                listIndustry = (List<Industry>)new IndustryViewModel().get();
                Company.CompanySession = new Company();
                Company.CompanySession.Industries = new List<Industry>();
                Company.CompanySession.Industries = listIndustry;
                Company.CompanySession.SelectedView = "1";
                Company.CompanySession.PosUser = SessionController.getUserSession();
                return View("Index", Company.CompanySession);
            }
            else
            {
                return RedirectToAction("SignIn", "User", null);
            }
        }

        public ActionResult GoToDashBoard(int userId)
        {
            return RedirectToAction("DashBoard", "User", new { id = userId });
        }

        [HttpPost]
        public ActionResult CreateCompany(Company company)
        {
            ViewBag.Active = "active";
            company.PosUser = Company.CompanySession.PosUser;
            if (Request.Files["logo"].ContentLength > 0)
            {
                company.Files = Request.Files;
            }
            else
            {
                company.Files = Company.CompanySession.Files;
                double a = Company.CompanySession.Files["logo"].InputStream.Length;
            }
            if (Company.CompanySession != null && Company.CompanySession.Products != null)
            {
                company.Products = Company.CompanySession.Products;
                company.backProduct = true;
            }
            company.PathPictureLogo += Server.MapPath("~/CreateWebSite");
            company.PathPictureProfile += Server.MapPath("~/CreateWebSite");
            company.SelectedView = "2";
            if (Company.CompanySession.Layout != null) company.Layout = Company.CompanySession.Layout;
            Company.CompanySession = company;
            return View("Index", Company.CompanySession);
        }

        public ActionResult GetImageProducts(int index)
        {
            MemoryStream memoryStream = new MemoryStream();

            Company.CompanySession.Products[index].Images[0].ImageFile.InputStream.Position = 0;
            Company.CompanySession.Products[index].Images[0].ImageFile.InputStream.CopyTo(memoryStream);
            double a = Company.CompanySession.Products[index].Images[0].ImageFile.InputStream.Length;
            return File(memoryStream.ToArray(), "image/png");
        }

        public ActionResult GetListImageProducts(int indexProduct, int indexImage)
        {
            MemoryStream memoryStream = new MemoryStream();
            Company.CompanySession.Products[indexProduct].Images[indexImage].ImageFile.InputStream.Position = 0;
            Company.CompanySession.Products[indexProduct].Images[indexImage].ImageFile.InputStream.CopyTo(memoryStream);
            return File(memoryStream.ToArray(), "image/png");
        }
        public ActionResult GetBackgroundLayout()
        {
            MemoryStream memoryStream = new MemoryStream();
            Company.CompanySession.Layout.ImageBackgroud.InputStream.Position = 0;
            Company.CompanySession.Layout.ImageBackgroud.InputStream.CopyTo(memoryStream);
            string backgroud64 = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
            return Content(backgroud64);
        }

        public ActionResult GetImageCompany(int index)
        {
            try
            {

                MemoryStream memoryStream = new MemoryStream();
                if (index == 0)
                {

                    Company.CompanySession.Files["logo"].InputStream.Position = 0;
                    Company.CompanySession.Files["logo"].InputStream.CopyTo(memoryStream);
                    string logo64 = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                    return Content(logo64);
                }
                else
                {
                    Company.CompanySession.Files["profile"].InputStream.Position = 0;
                    Company.CompanySession.Files["profile"].InputStream.CopyTo(memoryStream);
                    string profile64 = "data:image/png;base64," + Convert.ToBase64String(memoryStream.ToArray());
                    return Content(profile64);
                }

            }
            catch (Exception e)
            {
                string adds = e.Message;
            }
            return null;
        }

        [HttpPost]
        public ActionResult SaveProduct(Product product)
        {
            if (Request.Files.Count > 0 && Request.Files.Get("mainimage").ContentLength > 0)
            {
                SaveProductSession(product, Request);
                if (Company.CompanySession.Products != null && Company.CompanySession.Products.Count >= 2)
                {
                    bool productIsEqual = new Utility().productIsEquals(Company.CompanySession.Products[Company.CompanySession.Products.Count - 2], Company.CompanySession.Products[Company.CompanySession.Products.Count - 1]);
                    if (!(productIsEqual))
                    {
                        Company.CompanySession.SelectedView = "2";
                        Company.CompanySession.backProduct = false;
                        Product.ProductSession = product;
                        ModelState.Clear();

                    }
                    else
                    {
                        Company.CompanySession.Products[Company.CompanySession.Products.Count - 1].MessageError = "product already exist!";
                        Company.CompanySession.SelectedView = "2";
                        Company.CompanySession.backProduct = false;
                    }
                }
                else
                {
                    Company.CompanySession.SelectedView = "2";
                    Company.CompanySession.backProduct = false;
                    Product.ProductSession = product;
                    ModelState.Clear();
                }

            }
            else
            {
                Product.ProductSession = product;
                Company.CompanySession.Products = new List<Product>();
                Company.CompanySession.Products.Add(product);
                Company.CompanySession.SelectedView = "2";
                Company.CompanySession.backProduct = false;
            }

            return View("Index", Company.CompanySession);
        }

        public void SaveProductSession(Product product, HttpRequestBase request)
        {
            if (Company.CompanySession.Products != null)
            {
                mountProduct(product, request);
            }
            else
            {
                Company.CompanySession.Products = new List<Product>();
                mountProduct(product, request);
            }
        }

        public void mountProduct(Product product, HttpRequestBase request)
        {
            int countimage = 0;
            product.Images = new List<Image>();
            product.Company = Company.CompanySession;
            foreach (string fileName in request.Files)
            {
                HttpPostedFileBase imageProduct = request.Files[fileName];
                if (imageProduct.ContentLength > 0)
                {
                    countimage++;
                    Image image = new Image();
                    image.AbsolutePath = Server.MapPath("~/CreateWebSite");
                    image.RelativePath = "/CreateWebSite";
                    image.ImageFile = imageProduct;
                    image.Product = product;
                    product.Images.Add(image);
                }

            }
            ViewBag.ModalActive = true;
            Company.CompanySession.Products.Add(product);
        }

        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {

            if (Company.CompanySession.Products != null && Company.CompanySession.Products.Count > 0)
            {
                ViewBag.company = Company.CompanySession;
                Company.CompanySession.SelectedView = "3";
                Company.CompanySession.backProduct = false;
            }
            else
            {
                Company.CompanySession.SelectedView = "2";
                Company.CompanySession.backProduct = true;              
            }

            return View("Index", Company.CompanySession);
        }

        public ActionResult BackToBasicInformations(Product product)
        {
            /*if (Company.CompanySession.logoProfile == null)
          {
              Company.CompanySession.logoProfile = new UtilityViewModel().convertImage(Company.CompanySession.Files);
          }*/
            Company.CompanySession.backCompany = true;
            Company.CompanySession.SelectedView = "1";
            return RedirectToAction("Index", Company.CompanySession);
        }

        [HttpPost]
        public ActionResult BackProduct(Layout layout)
        {
            Company.CompanySession.backProduct = true;
            Company.CompanySession.SelectedView = "2";
            return View("Index", Company.CompanySession);
        }

        public ActionResult BackToLayout()
        {
            Company.CompanySession.SelectedView = "3";
            return RedirectToAction("Index", Company.CompanySession);
        }

        [HttpPost]
        public ActionResult CreateLayout(Layout layout)
        {
            if (Request.Files[0].ContentLength > 0)
            {
                layout.ImageBackgroud = Request.Files[0];
            }
            else
            {
                layout.ImageBackgroud = Company.CompanySession.Layout.ImageBackgroud;
            }
            layout.PathPictureBackground = Server.MapPath("~/CreateWebSite");
            Company.CompanySession.Layout = layout;
            Company.CompanySession.SelectedView = "4";
            return View("Index", Company.CompanySession);
        }
        public ActionResult MountCompany()
        {
            new UtilityViewModel().mountCompany(Company.CompanySession);
            return RedirectToAction("DashBoard", "User", new { id = Company.CompanySession.PosUser.PosUserId });
        }
    }
}