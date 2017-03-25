using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace _8pos
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "UserValidation",
              url: "user/validation/{id}/{activationtoken}",
              defaults: new { controller = "User", action = "Validation" ,id = UrlParameter.Optional }
       );
            routes.MapRoute(
             name: "IndexCreate",
             url: "create/company/{userid}",
             defaults: new { controller = "Create", action = "IndexCreate", id = UrlParameter.Optional }
    );

            routes.MapRoute(
             name: "GoToDashBoard",
             url: "create/user/{userid}",
             defaults: new { controller = "Create", action = "GoToDashBoard", id = UrlParameter.Optional }
    );

            routes.MapRoute(
         name: "Default",
         url: "{controller}/{action}/{id}",
         defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
     );



        }
        
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            //To:DO
        }
    }
}
