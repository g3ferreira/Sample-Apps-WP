using _8pos.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace _8pos.Controllers.Utilities
{
    public class Utility
    {
        string mySalt = BCrypt.Net.BCrypt.GenerateSalt(10);        
        public string encryptPassword(string password)
        {
            string hashPassword = BCrypt.Net.BCrypt.HashPassword(password, mySalt);
            return hashPassword;
        }

        public string encryptToken(string activationToken)
        {
            string hashPassword = BCrypt.Net.BCrypt.HashPassword(activationToken, mySalt);
            if (hashPassword.Contains("."))
            {
                hashPassword = hashPassword.Replace(".", "!");
            }
            if (hashPassword.Contains("/"))
            {
                hashPassword = hashPassword.Replace("/", "#!");
            }

            return hashPassword;
        }

        public bool productIsEquals(Product productPrevious, Product productActual)
        {
            bool ret = false;
            List<PropertyInfo> differences = new List<PropertyInfo>();
            foreach (PropertyInfo property in productPrevious.GetType().GetProperties())
            {
                if (!(property.Name.Equals("ImagesByte")) && (!(property.Name.Equals("MessageError"))) && (!(property.Name.Equals("ProductSession"))))
                {
                    if (property.Name.Equals("Category"))
                    {
                        Category category1 = (Category)property.GetValue(productPrevious, null);
                        Category category2 = (Category)property.GetValue(productActual, null);
                        if (category1.Category_Id.Equals(category2.Category_Id))
                        {
                            ret = true;
                            // differences.Add(property);
                        }
                        else
                        {
                            ret = false;
                            break;
                            // differences.Add(property);
                        }
                    }
                    else if ((property.Name.Equals("Images")))
                    {
                        List<Image> images = (List<Image>)property.GetValue(productPrevious, null);
                        List<Image> images2 = (List<Image>)property.GetValue(productActual, null);
                        if (!(images.Count != images2.Count))
                        {

                            for (int i = 0; i < images.Count; i++)
                            {
                                if (!(images[i].ImageFile.ContentLength != images2[i].ImageFile.ContentLength))
                                {
                                    ret = true;
                                }
                                else
                                {
                                    ret = false;
                                    break;
                                }
                            }

                        }
                        else
                        {
                            ret = false;
                            break;
                        }
                    }
                    else
                    {
                        object value1 = property.GetValue(productPrevious, null);
                        object value2 = property.GetValue(productActual, null);
                        if (value1.Equals(value2))
                        {
                            ret = true;
                            // differences.Add(property);
                        }
                        else
                        {
                            ret = false;
                            break;
                        }
                    }

                }
            }
            return ret;
        }


    }
}