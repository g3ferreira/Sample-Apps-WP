using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using NHibernate;
using NHibernate.Linq;
using _8pos.App_Data;
using _8pos.Models.Entity;
using System.Web.Mvc;
using System.Reflection;
using _8pos.Controllers.Model;
using _8pos.Controllers.ViewModel;
using System.Globalization;
using System.Threading;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]

sealed public class MultiPropertyValidation : ValidationAttribute, IClientValidatable
{
    private readonly string[] _fields;

    public MultiPropertyValidation(string[] fields)
    {
        _fields = fields;
    }
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {

        if (validationContext.ObjectType.Name.Equals("PosUser"))
        {
            PosUser posUser = validationContext.ObjectInstance as PosUser;
            if (posUser.PosUserId == 0)
            {
                return userValidation(_fields, validationContext);
            }
        }
        if (validationContext.ObjectType.Name.Equals("Company"))
        {
            return userValidation(_fields, validationContext);
        }


        return null;
    }

    public ValidationResult userValidation(string[] properties, ValidationContext validationContext)
    {
        foreach (string property in properties)
        {
            UserViewModel userViewModel = new UserViewModel();
            PropertyInfo propertyInfo = validationContext.ObjectType.GetProperty(property);
            string fieldValue = propertyInfo.GetValue(validationContext.ObjectInstance, null).ToString();
            if (propertyInfo.Name.Equals("UserName"))
            {
                if (!(userViewModel.userNameValidation(fieldValue))) return new ValidationResult(string.Empty);

            }
            if (propertyInfo.Name.Equals("Email"))
            {
                if (!(userViewModel.emailValidation(fieldValue))) return new ValidationResult(string.Empty);
            }
            if (propertyInfo.Name.Equals("Birthday"))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                DateTime dt = Convert.ToDateTime(fieldValue);
                DateTime dtNow = DateTime.Now;
                int age = dtNow.Year - dt.Year;
                if (age == 21)
                {
                    if (dt.Month == dtNow.Month)
                    {
                        if (dt.Day <= dtNow.Day)
                        {
                            return null;
                        }
                        else
                        {
                            return new ValidationResult(string.Empty);
                        }
                    }
                    else if (dt.Month < dtNow.Month)
                    {
                        return null;
                    }
                    else
                    {
                        return new ValidationResult(string.Empty);
                    }

                }
                else if (age < 21)
                {
                    return new ValidationResult(string.Empty);
                }
                else
                {
                    return null;
                }
            }
        }

        return null;
    }

    public ValidationResult companyValidation(string[] properties, ValidationContext validationContext)
    {
        foreach (string property in properties)
        {
            CompanyViewModel companyViewModel = new CompanyViewModel();
            PropertyInfo propertyInfo = validationContext.ObjectType.GetProperty(property);
            string fieldValue = propertyInfo.GetValue(validationContext.ObjectInstance, null).ToString();
            if (propertyInfo.Name.Equals("Email"))
            {
                if (!(companyViewModel.emailValidation(fieldValue))) return new ValidationResult(string.Empty);
            }
        }
        return null;
    }

    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        yield return new ModelClientValidationRule
        {
            ErrorMessage = this.ErrorMessage,
            ValidationType = "multifield"
        };
    }
}

