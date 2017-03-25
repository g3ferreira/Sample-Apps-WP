using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8pos.Models.Entity
{
    public class Image
    {
        public virtual int Image_Id { get; set; }
        public virtual string AbsolutePath { get; set; }
        public virtual string RelativePath { get; set; }
        public virtual Product Product { get; set; }
        public virtual HttpPostedFileBase ImageFile { get; set; }

    }
}