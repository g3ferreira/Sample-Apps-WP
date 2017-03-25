using _8pos.Models.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8pos.Models.Mapping
{
    public class ProfileMap : ClassMap<Profile>
    {
        public ProfileMap()
        {
            Id(p => p.ProfileId).Column("profile_id").GeneratedBy.Increment();
            Map(p => p.Type);        
            Table("profile");
        }
    }
}