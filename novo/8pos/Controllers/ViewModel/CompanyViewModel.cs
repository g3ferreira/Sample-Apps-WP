using _8pos.App_Data;
using _8pos.App_Data.DAO;
using _8pos.Controllers.Model;
using _8pos.Models.Entity;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _8pos.Controllers.ViewModel
{
    public class CompanyViewModel : SuperDAO<Company>
    {
        public bool createCompany(Company company)
        {
            bool retValue = true;
            company.PosUser = new UserViewModel().getById(company.PosUser.PosUserId);
            company.Layout = new LayoutViewModel().getById(company.Layout.LayoutId);
            insert(company);
            return retValue;
        }

        public bool emailValidation(string email)
        {
            using (ISession session = SessionFactory.openSession())
            {
                int countUsers = session.Query<Company>().Where(u => u.Email.Trim() == email.Trim()).ToList().Count;
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