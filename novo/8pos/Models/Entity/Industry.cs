using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8pos.Models.Entity
{
    public class Industry
    {

        public virtual int Industry_Id { get; set; }
        
        [Display(Name = "Segment")]
        public virtual string Type { get; set; }
        public virtual IList<Company> Companies { get; set; }
    }
}