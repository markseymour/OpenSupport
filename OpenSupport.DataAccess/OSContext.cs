using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using OpenSupport.Core.Models;
using System.Data.EntityClient;
using OpenSupport.Core.Services;

namespace OpenSupport.DataAccess
{
    public class OSContext : DbContext
    {
        public OSContext()
        {
            using (EntityConnection con = new EntityConnection(SiteManager.LoadSite().ConnectionString))
            {

            }
        }


    }
}
