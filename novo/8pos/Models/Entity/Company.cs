using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _8pos.Models.Entity
{
    public class Company
    {
        public virtual int CompanyId { get; set; }

        [Required(ErrorMessage = "Enter your company name")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [Display (Name = "Company's name*")]
        public virtual string CompanyName { get; set; }

        [Required(ErrorMessage = "Enter your industry name")]
        [StringLength(10, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display (Name = "Segment*")]
        public virtual string SelectedIndustry { get; set; }

        [Required(ErrorMessage = "Enter your email")]
        [DataType(DataType.EmailAddress)]
        //[MultiPropertyValidation(fields: new string[] { "Email" }, ErrorMessage = "Email is already being used")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [Display (Name = "Email*")]
        public virtual string Email { get; set; }

        [Required(ErrorMessage = "Enter your phone number")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [Display (Name = "Phone number*")]
        public virtual string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Enter your address")]
        [StringLength(200, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [Display(Name = "Address*")]
        public virtual string Address { get; set; }

        [Required(ErrorMessage = "Enter your zip code")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [Display(Name = "Zip Code*")]
        public virtual string ZipCode { get; set; }

        [Required(ErrorMessage = "Enter your state")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "State*")]
        public virtual string State { get; set; }

        [Required(ErrorMessage = "Enter your country")]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [Display(Name = "Country*")]
        public virtual string Country { get; set; }

        [Required(ErrorMessage = "Describe yout product or service")]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [Display(Name = "About*")]
        public virtual string About { get; set; }

        [Display(Name = "Logo*")]
        public virtual string PathPictureLogo { get; set; }
        public virtual string PathPictureProfile { get; set; }
        public virtual IList<Industry> Industries { get; set; }
        public virtual IList<Product> Products { get; set; }
        public virtual Layout Layout { get; set; }
        public virtual PosUser PosUser { get; set; }
        public virtual string SelectedView { get; set; }
        public virtual HttpFileCollectionBase Files { get; set; }
        public virtual List<byte[]> logoProfile { get; set;}
        public virtual bool backProduct { get; set; }
        public virtual bool backCompany { get; set; }
        public static Company CompanySession { get; set; }
    }
}