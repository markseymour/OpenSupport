using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSupport.Core.Models;
using OpenSupport.Models.Entities;

namespace OpenSupport.Dashboard.Services
{
    public interface IUserService : IDependency
    {
        User GetCurrentUser();
    }
}
