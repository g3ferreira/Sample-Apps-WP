using _8pos.App_Data;
using _8pos.App_Data.DAO;
using _8pos.Controllers.ViewModel;
using _8pos.Models.Entity;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _8pos.Controllers.Model
{
    public class UserViewModel : UserDAO<PosUser>
    {
        public bool validationToken(PosUser posUser, string activationToken)
        {
            string requestToken = activationToken;
            string posToken = posUser.ActivationToken;
            bool validation = posToken.Equals(requestToken);
            return validation;
        }


        public bool validatePassword(string password, string hashPassword)
        {
            bool doesPasswordMatch = BCrypt.Net.BCrypt.Verify(password, hashPassword);
            return doesPasswordMatch;
        }

        public void updateUserStatus(PosUser posUser, int status)
        {
            posUser.Status = new StatusViewModel().getById(status);
            new UserViewModel().update(posUser);
        }

        public bool userNameValidation(string userName)
        {
            using (ISession session = SessionFactory.openSession())
            {
                int countUsers = session.Query<PosUser>().Where(u => u.UserName.Trim() == userName.Trim()).ToList().Count;
                if (countUsers == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool emailValidation(string email)
        {
            using (ISession session = SessionFactory.openSession())
            {
                int countUsers = session.Query<PosUser>().Where(u => u.Email.Trim() == email.Trim()).ToList().Count;
                if (countUsers == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}