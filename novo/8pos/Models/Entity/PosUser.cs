using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8pos.Models.Entity
{
    public class PosUser
    {
        public virtual int PosUserId { get; set; }

        [Required(ErrorMessage = "Enter your first name")]
        [DataType(DataType.Text)]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 2)]
        [Display(Name = "First name")]
        public virtual string FirstName { get; set; }

        [Required(ErrorMessage = "Enter your last name")]
        [DataType(DataType.Text, ErrorMessage = "Only text is accepted")]
        [StringLength(30, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 5)]
        [Display(Name = "Last name")]
        public virtual string LastName { get; set; }

        [Required(ErrorMessage = "Enter your username")]
        [DataType(DataType.Text, ErrorMessage = "Only text is accepted")]
        [StringLength(20, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 5)]
        [Display(Name = "Username")]
        [Remote("ValidateUserName", "User")]
        public virtual string UserName { get; set; }

        [Required(ErrorMessage = "Enter your email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "The email is invalid.")]
        [StringLength(100, ErrorMessage = "Too short", MinimumLength = 10)]
        [Display(Name = "Email")]
        [Remote("ValidateEmail", "User")]
        public virtual string Email { get; set; }

        [Required(ErrorMessage = "Enter your birthday")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{MM-DD-YYYY}")]
        [Display(Name = "Birthday")]
        [MultiPropertyValidation(fields: new string[] { "Birthday" }, ErrorMessage = "You must be over 20 years old")]
        public virtual DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Enter your gender")]
        [Display(Name = "Gender")]
        public virtual string Gender { get; set; }

        [Required(ErrorMessage = "Enter your password")]
        [StringLength(100, ErrorMessage = "The {0} must be between {2} and {1} characters.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public virtual string Password { get; set; }

        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Password not match")]
        [Display(Name = "Confirm Password")]
        public virtual string ConfirmPassword { get; set; }

        [Display(Name = "I agree with a")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Accept terms")]
        public virtual bool AcceptTerms { get; set; }

        public virtual string ActivationToken { get; set; }
        public virtual Status Status { get; set; }
        public virtual IList<Company> Companies { get; set; }
        public virtual string SelectedView { get; set; }
        public virtual string MessageError { get; set; }
        public virtual Profile Profile { get; set; }
    }
}