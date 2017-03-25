using _8pos.Models.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8pos.Models.Mapping
{
    public class ImageMap : ClassMap<Image>
    {
        public ImageMap()
        {
            Id(c => c.Image_Id).GeneratedBy.Increment();
            //Map(c => c.AbsolutePath);
            Map(c => c.RelativePath);
            References(c => c.Product).Not.LazyLoad();
            Table("image");
        }
    }
}