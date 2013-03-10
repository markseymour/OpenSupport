using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSupport.Core.Models
{
    public interface ISite
    {
        string SiteName { get; set; }
        string ConnectionString { get; set; }
    }
}
