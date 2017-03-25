using _8pos.Controllers.Model;
using _8pos.Controllers.Utilities;
using _8pos.Models.Entity;
using _8pos.Models.ModelsInterface;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8pos.App_Data.DAO
{
    public class UserDAO<T> : SuperDAO<PosUser>
    {
        public PosUser login(string userName, string password)
        {
            PosUser user = new PosUser();
            using (ISession session = SessionFactory.openSession())
            {
                List<PosUser> listPosUser = session.Query<PosUser>().Where(u => u.UserName.Trim() == userName.Trim()).ToList<PosUser>();
                if (listPosUser.Count > 0)
                {
                    user = listPosUser[0];
                    if (new UserViewModel().validatePassword(password, listPosUser[0].Password))
                    {
                        user.MessageError = string.Empty;
                        return user;
                    }
                    else
                    {
                        user.MessageError = "Invalid password!";
                        return user;
                    }
                }
                else
                {
                    user.MessageError = "Invalid username";
                    return user;
                }
            }
        }
    }
}