using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using _8pos.Models.Entity;

namespace _8pos.Models.Mapping
{
    public class PosUserMap : ClassMap<PosUser>
    {

        public PosUserMap()
        {
            Id(u => u.PosUserId).Column("posuser_id").GeneratedBy.Increment();
            Map(u => u.UserName);
            Map(u => u.FirstName).Column("first_name");
            Map(u => u.LastName).Column("last_name");
            Map(u => u.Email);
            Map(u => u.Birthday);
            Map(u => u.Gender);
            Map(u => u.Password);
            Map(u => u.ConfirmPassword);
            Map(u => u.AcceptTerms);
            Map(u => u.ActivationToken);
            HasMany(u => u.Companies).Not.LazyLoad();
            References(u => u.Status).Not.LazyLoad();
            References(u => u.Profile).Not.LazyLoad();
            Table("posuser");
        }

    }
}