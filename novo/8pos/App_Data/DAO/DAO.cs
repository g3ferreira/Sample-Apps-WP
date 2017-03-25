using _8pos.Controllers.Utilities;
using _8pos.Models.Entity;
using _8pos.Models.ModelsInterface;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _8pos.App_Data.DAO
{
    public class SuperDAO<T>  : IModelCrud<T> where T : class 
    {
        public void insert(T entidade)
        {
            using (ISession session = SessionFactory.openSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entidade);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw ex;
                    }
                }
            }
        }
        public void update(T entidade)
        {
            using (ISession session = SessionFactory.openSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entidade);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Error Update " + ex.Message);
                    }
                }
            }
        }
        public void delete(T entidade)
        {
            using (ISession session = SessionFactory.openSession())
            {
                using (ITransaction transacao = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entidade);
                        transacao.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (!transacao.WasCommitted)
                        {
                            transacao.Rollback();
                        }
                        throw new Exception("Error Delete : " + ex.Message);
                    }
                }
            }
        }
        public T getById(int Id)
        {
            using (ISession session = SessionFactory.openSession())
            {
                return session.Get<T>(Id);
            }
        }
        public IList<T> get()
        {
            using (ISession session = SessionFactory.openSession())
            {
                List<T> users = new List<T>();
                try
                {

                    users = (from c in session.Query<T>() select c).ToList();
                }
                catch (Exception b)
                {

                    string err = b.InnerException.Message;
                }
                return users;
            }
        }

    }
}