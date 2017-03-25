using _8pos.Models.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8pos.Models.Mapping
{
    public class CompanyMap : ClassMap<Company>
    {
        public CompanyMap()
        {
            Id(c => c.CompanyId).Column("company_id").GeneratedBy.Increment();
            Map(c => c.CompanyName).Column("company_name");
            Map(c => c.Email);
            Map(c => c.PhoneNumber).Column("phone_number");
            Map(c => c.ZipCode).Column("zip_code");
            Map(c => c.Address);
            Map(c => c.State);
            Map(c => c.Country);
            Map(c => c.About);
            Map(c => c.PathPictureLogo).Column("path_picture_logo");
            Map(c => c.PathPictureProfile).Column("path_picture_profile");
            References(c => c.PosUser).Not.LazyLoad();
            References(c => c.Layout).Not.LazyLoad();
            HasMany(c => c.Products).Not.LazyLoad();
            HasManyToMany(c => c.Industries).Not.LazyLoad().Table("company_industry");
            Table("company");

        }
    }
}