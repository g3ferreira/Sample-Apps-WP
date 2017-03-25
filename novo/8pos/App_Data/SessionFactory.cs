using _8pos.Models;
using _8pos.Models.Entity;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Data;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace _8pos.App_Data
{
    public class SessionFactory
    {
       // private static string connectionString = "Server=192.168.100.71; Port=5432; User Id=dba_8pos; Password=123; Database=db8POSDev";
        private static string connectionString = "Server=localserver; Port=5432; User Id=g3ferreira; Password=123; Database=db8POS";
       // private static string connectionString = "Server=192.168.100.71; Port=5432; User Id=dba_8pos; Password=123; Database=db8POSTeste";

        private static ISessionFactory session;
        public static ISessionFactory openSessionFactory()
        {
            if (session != null)
                return session;

            var autoMap = AutoMap.AssemblyOf<Entity>().Where(t => typeof(Entity).IsAssignableFrom(t));
            try
            {
                IPersistenceConfigurer configDB = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(connectionString);
                //var configMap = Fluently.Configure().Database(configDB).Mappings(c => c.FluentMappings.AddFromAssemblyOf<Models.Usuario>());
                //session = configMap.BuildSessionFactory();               
                session = Fluently.Configure().Database(configDB).Mappings(m => m.FluentMappings
                .AddFromAssemblyOf<Category>()
                .AddFromAssemblyOf<Company>()
                .AddFromAssemblyOf<Image>()
                .AddFromAssemblyOf<Industry>()
                .AddFromAssemblyOf<Layout>()
                .AddFromAssemblyOf<Product>()
                .AddFromAssemblyOf<Status>()
                .AddFromAssemblyOf<PosUser>()
                .AddFromAssemblyOf<Profile>()
                ).

                ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true)).BuildSessionFactory();
            }
            catch (Exception ec)
            {
                string eee = ec.Message;
            }
            return session;
        }
        public static ISession openSession()
        {
            return openSessionFactory().OpenSession();
        }
    }
}