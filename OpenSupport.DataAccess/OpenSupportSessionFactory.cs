using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using OpenSupport.Core.Models;
using OpenSupport.Core.Services;

namespace OpenSupport.DataAccess
{
    public class OpenSupportSessionFactory
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();

                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                .ConnectionString(SiteManager.CurrentSite().ConnectionString))
                .Mappings(m => m.AutoMappings
                    .Add(AutoMap.AssemblyOf<IEntity>(new AutomappingConfiguration())
                    .Conventions.AddFromAssemblyOf<AutomappingConfiguration>()))
                    .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
