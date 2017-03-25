using _8pos.Models.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8pos.Models.Mapping
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(p => p.ProductId).GeneratedBy.Increment();
            Map(p => p.Name);
            Map(p => p.Price);
            Map(p => p.Description);
            HasMany(p => p.Images).Not.LazyLoad();
            References(p => p.Category);
            References(p => p.Company);
            Table("product");

        }
    }
}