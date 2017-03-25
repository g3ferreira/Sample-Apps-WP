using _8pos.Models.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8pos.Models.Mapping
{
    public class IndustryMap : ClassMap<Industry>
    {
        public IndustryMap()
        {
            Id(i => i.Industry_Id).GeneratedBy.Increment();
            Map(i => i.Type);
            HasManyToMany(i => i.Companies).Not.LazyLoad().Table("company_industry"); ;
            Table("industry");

        }
    }
}