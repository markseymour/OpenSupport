using OpenSupport.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSupport.Core.Services
{
    public class SupportServices : ISupportServices
    {
        public SiteSettingsRecord GetSite()
        {
            return new SiteSettingsRecord();
        }
    }
}