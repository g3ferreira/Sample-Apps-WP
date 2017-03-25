using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8pos.Models.Entity
{
    public class Category
    {
        public virtual int Category_Id { get; set; }
        public virtual string Description { get; set; }
        public virtual Product Product { get; set; }
        public virtual string SelectedCategory { get; set; }
    }
}