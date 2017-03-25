using _8pos.Controllers.Model;
using _8pos.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace _8pos.Controllers.ViewModel
{
    public class UtilityViewModel
    {

        public void mountCompany(Company company)
        {
            CompanyViewModel companyViewModel = new CompanyViewModel();

            new LayoutViewModel().insert(company.Layout);
            company.Industries = new List<Industry>();
            company.Industries.Add(new IndustryViewModel().getById(Convert.ToInt32(company.SelectedIndustry)));
            //company.PosUser = new UserViewModel().getById(1);
            List<Product> listProducts = new List<Product>();
            listProducts = (List<Product>)company.Products;
            company.Products = null;
            new CompanyViewModel().insert(company);
            company.PathPictureLogo += @"\u" + company.PosUser.PosUserId + @"\c" + company.CompanyId + @"\images\logo";
            company.PathPictureProfile += @"\u" + company.PosUser.PosUserId + @"\c" + company.CompanyId + @"\images\profile";
            
            if (company.Files != null && company.Files.Get("logo").ContentLength > 0)
            {
                saveImage(company.Files.Get("logo"), company.PathPictureLogo, company.Files.Get("logo").FileName);
                saveImage(company.Files.Get("profile"), company.PathPictureProfile, company.Files.Get("profile").FileName);
            }
           /* else if (company.logoProfile[1].Length == 0)
            {
                saveImage(company.Files.Get("logo"), company.PathPictureLogo, company.Files.Get("logo").FileName);
                company.PathPictureProfile = string.Empty;
            }
            else if (company.logoProfile[1].Length > 0)
            {
                saveImageByte(company.logoProfile[0], company.PathPictureLogo, company.Files.Get("logo").FileName);
                saveImageByte(company.logoProfile[1], company.PathPictureLogo, company.Files.Get("logo").FileName);
            }*/
            company.PathPictureLogo = @"\CreateWebSite" + Regex.Split(company.PathPictureLogo, "CreateWebSite")[1] + @"\" + company.Files.Get("logo").FileName;
            company.PathPictureProfile = @"\CreateWebSite" + Regex.Split(company.PathPictureProfile, "CreateWebSite")[1] + @"\" + company.Files.Get("profile").FileName;
            company.Layout.PathPictureBackground += @"\u" + company.PosUser.PosUserId + @"\c" + company.CompanyId + @"\images\background";
            saveImage(company.Layout.ImageBackgroud, company.Layout.PathPictureBackground, company.Layout.ImageBackgroud.FileName);
            company.Layout.PathPictureBackground = @"\CreateWebSite" + Regex.Split(company.Layout.PathPictureBackground, "CreateWebSite")[1] + @"\" + company.Layout.ImageBackgroud.FileName;
            new LayoutViewModel().update(company.Layout);
            new CompanyViewModel().update(company);
            saveProductsImages(listProducts, company);
            company.Products = listProducts;
        }

        public void saveProductsImages(List<Product> listProducts, Company company)
        {
            foreach (var product in listProducts)
            {
                List<Image> listImages = new List<Image>();
                listImages = (List<Image>)product.Images;
                product.Images = null;
                product.Company = company;
                product.Category = new CategoryViewModel().getById(product.Category.Category_Id);
                new ProductViewModel().insert(product);
                int countImage = 0;
                foreach (var image in listImages)
                {
                    image.AbsolutePath += @"\u" + company.PosUser.PosUserId + @"\c" + company.CompanyId + @"\images\products\" + product.ProductId;
                    new ImageViewModel().insert(image);
                    saveImage(image.ImageFile, image.AbsolutePath, countImage + ".png");
                    image.AbsolutePath = image.AbsolutePath + @"\" + countImage + ".png";
                    image.RelativePath = @"\CreateWebSite" + @"\u" + company.PosUser.PosUserId + @"\c" + company.CompanyId + @"\images\products\" + product.ProductId + @"\" + countImage + ".png";
                    new ImageViewModel().update(image);
                    countImage++;

                }
                product.Images = listImages;

            }
        }

        public void saveImage(HttpPostedFileBase image, string path, string fileName)
        {
            if (Directory.Exists(path))
            {
                image.SaveAs(path + @"\" + fileName);
            }
            else
            {
                Directory.CreateDirectory(path);
                image.SaveAs(path + @"\" + fileName);
            }
        }
        public void saveImageByte(byte[] image, string path, string fileName)
        {          
            if (Directory.Exists(path))
            {
                FileStream fs = new FileStream(path + @"\" + fileName, FileMode.CreateNew);
                fs.Write(image, 0, image.Length);

            }
            else
            {
                Directory.CreateDirectory(path);
                FileStream fs = new FileStream(path + @"\" + fileName, FileMode.CreateNew);
                fs.Write(image, 0, image.Length);

            }




        }


        public List<byte[]> convertImage(HttpFileCollectionBase files)
        {
            List<byte[]> images = new List<byte[]>();

            if (files != null)
            {
                foreach (string fileName in files)
                {
                    HttpPostedFileBase file = files[fileName];
                    using (Stream inputStream = file.InputStream)
                    {
                        MemoryStream memoryStream = inputStream as MemoryStream;
                        if (memoryStream == null)
                        {
                            memoryStream = new MemoryStream();
                            inputStream.CopyTo(memoryStream);
                        }
                        //  company.logoProfile.Add(memoryStream.ToArray());
                        images.Add(memoryStream.ToArray());
                    }
                }
            }

            return images;
        }

        public byte[] convertImageProduct(HttpPostedFileBase file)
        {
            byte[] imageByte = null;
            if (file != null)
            {
                using (Stream inputStream = file.InputStream)
                {
                    MemoryStream memoryStream = inputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        inputStream.CopyTo(memoryStream);
                    }
                    //  company.logoProfile.Add(memoryStream.ToArray());
                    imageByte = memoryStream.ToArray();
                }

            }

            return imageByte;
        }
    }
}

