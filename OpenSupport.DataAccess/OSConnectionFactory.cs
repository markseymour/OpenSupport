using OpenSupport.Core.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSupport.DataAccess
{
    public class OSConnectionFactory : IDbConnectionFactory
    {
        public DbConnection CreateConnection(String nameOrConnectionString)
        {
            var siteConnectionString = SiteManager.LoadSite().ConnectionString;
            var sqlFactory = new SqlConnectionFactory();
            return sqlFactory.CreateConnection(siteConnectionString);
        }
    }
}
