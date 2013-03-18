using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using OpenSupport.Core.Models;
using OpenSupport.Models.Entities;
using WebMatrix.WebData;

namespace OpenSupport.Dashboard.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetCurrentUser()
        {
            var currentUserName = HttpContext.Current.User.Identity.Name;
            return _userRepository.FetchAll().FirstOrDefault(x => x.UserName == currentUserName);
        }
    }
}
