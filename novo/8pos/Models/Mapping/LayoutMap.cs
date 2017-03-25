using _8pos.Models.Entity;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8pos.Models.Mapping
{
    public class LayoutMap : ClassMap<Layout>
    {
        public LayoutMap()
        {
            Id(l => l.LayoutId).Column("layout_id").GeneratedBy.Increment();
            Map(l => l.ColorPattern).Column("color_pattern");
            Map(l => l.Theme);
            Map(l => l.Slogan);
            Map(l => l.ShortDescription).Column("short_description");
            Map(l => l.PathPictureBackground).Column("path_picture_background");
            Table("layout");

        }
    }
}