using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSupport.Core.Models;
using OpenSupport.Models.Entities;

namespace OpenSupport.Dashboard.Services
{
    public interface IAuthenticationService : IDependency
    {
        bool ValidateUser(string username, string password);
        User CreateUser(string username, string password);
        void Login(string username, string password);
        void Logout();
    }
}
