using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSupport.Core.Models
{
    public interface IUser
    {
        String UserName { get; set; }
        String Email { get; set; }
        String Password { get; set; }
    }
}
