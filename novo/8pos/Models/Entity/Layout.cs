using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _8pos.Models.Entity
{
    public class Layout
    {
        public virtual int LayoutId { get; set; }

        [Required(ErrorMessage = "Enter your color pattern")]
        [Display(Name = "Color pattern*")]
        public virtual string ColorPattern { get; set; }

        [Required(ErrorMessage = "Enter your slogan")]
        [Display(Name = "Slogan*")]
        public virtual string Slogan { get; set; }

        [Required(ErrorMessage = "Enter your short description")]
        [Display(Name = "Short description*")]
        public virtual string ShortDescription { get; set; }
        
        [Required(ErrorMessage = "Enter your theme")]
        [Display(Name = "Choose your theme*")]
        public virtual string Theme { get; set; }

        public virtual string PathPictureBackground { get; set; }
        public virtual HttpPostedFileBase ImageBackgroud { get; set; }
        public virtual Company Company { get; set; }
    }
}