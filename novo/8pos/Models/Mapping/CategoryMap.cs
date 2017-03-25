using _8pos.Models.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8pos.Models.Mapping
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(c => c.Category_Id).GeneratedBy.Increment();
            Map(c => c.Description);
            Table("category");
        }
    }
}