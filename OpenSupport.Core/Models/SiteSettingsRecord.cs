﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OpenSupport.Core.Models
{
    public class SiteSettingsRecord : ISite
    {
        public string ConnectionString { get; set; }
        public string SiteName { get; set; }
        public string AdminUserName { get; set; }
        public string AdminPassword { get; set; }
    }
}