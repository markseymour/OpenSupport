using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using OpenSupport.Core.Models;
using OpenSupport.Core.Services;
using OpenSupport.Models;

namespace OpenSupport.DataAccess
{
    public class OpenSupportSessionFactory
    {
        private static FluentConfiguration GetConfiguration()
        {
            return Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2008
                .ConnectionString(SiteManager.CurrentSite().ConnectionString))
                .Mappings(m => m.AutoMappings
                    .Add(AutoMap.AssemblyOf<IEntity>(new AutomappingConfiguration())
                    .Conventions.AddFromAssemblyOf<AutomappingConfiguration>()));
        }

        public static ISessionFactory BuildSessionFactory()
        {
           return GetConfiguration().BuildSessionFactory();
        }

        public static ISessionFactory BuildInitialDatabase()
        {
            return GetConfiguration()
                .ExposeConfiguration(c => new SchemaExport(c).Execute(true, true, false))
                .BuildSessionFactory();
        }
    }
}
