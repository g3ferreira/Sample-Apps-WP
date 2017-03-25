using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _8pos.Models.Entity
{
    public class Product
    {
        public virtual int ProductId { get; set; }

        [Required(ErrorMessage = "Enter product name")]
        [Display(Name = "Name*")]
        public virtual string Name { get; set; }

        [Required(ErrorMessage = "Enter product price")]
        [Display(Name = "Price*")]
        public virtual string Price { get; set; }

        [Required(ErrorMessage = "Enter product category")]
        [Display(Name = "Category*")]
        public virtual Category Category { get; set; }

        [Required(ErrorMessage = "Enter product description")]
        [Display(Name = "Description*")]
        public virtual string Description { get; set; }

        public virtual Company Company { get; set; }
        public virtual IList<Image> Images { get; set; }
        public virtual List<byte[]> ImagesByte { get; set; }
        public static Product ProductSession { get; set; }
        public virtual string MessageError { get; set; }

    }
}