using _8pos.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8pos.Controllers.Utilities
{
    public class SessionController
    {
        public static bool userIsLogged(string userType)
        {
            var session = HttpContext.Current.Session;
            if (session["user"] != null && ((PosUser)session["user"]).Profile.Type.Equals(userType))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public static void setUserSession(PosUser user)
        {
            HttpContext.Current.Session["user"] = user;
        }
        public static PosUser getUserSession()
        {
             return (PosUser)HttpContext.Current.Session["user"];
           
        }
    }
}