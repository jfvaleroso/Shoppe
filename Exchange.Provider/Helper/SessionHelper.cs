using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System.Configuration;
using System.Reflection;
using Exchange.NHibernateBase.Mapping;

namespace Exchange.Provider.Helper
{
    public static class SessionHelper
    {
        public static ISessionFactory CreateSessionFactory(string connstr)
        {
            var connStr = ConfigurationManager.ConnectionStrings["ShoppeConn"].ConnectionString;
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connStr))
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetAssembly(typeof(UsersMap))))
                .BuildSessionFactory();
        }
    }
}
