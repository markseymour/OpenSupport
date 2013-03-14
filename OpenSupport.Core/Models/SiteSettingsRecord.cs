using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OpenSupport.Core.Models
{
    public class SiteSettingsRecord : ISite
    {
        [Required(ErrorMessage="Must provide a connection string")]
        public string ConnectionString { get; set; }
        public string SiteName { get; set; }
        [Required(ErrorMessage="Must provide administrator username")]
        public string AdminUserName { get; set; }
        [Required(ErrorMessage = "Must provide administrator password")]
        public string AdminPassword { get; set; }
    }
}