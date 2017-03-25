using _8pos.Models.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8pos.Models.Mapping
{
    public class StatusMap : ClassMap<Status>
    {
        public StatusMap()
        {
            Id(s => s.Status_Id).GeneratedBy.Increment();
            Map(s => s.Type);
        
            Table("status");
        }
    }
}