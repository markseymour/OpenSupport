using OpenSupport.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSupport.Core.Services
{
    public interface ISupportServices : IDependency
    {
        SiteSettingsRecord GetSite();
    }
}
