using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSupport.Core.Filters;
using OpenSupport.Core.Models;
using OpenSupport.DataAccess.Tools;
using OpenSupport.Models.Entities;
using System.Security.Cryptography;
using WebMatrix.WebData;

namespace OpenSupport.Dashboard.Services
{
    [InitializeMembership]
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<UserMembership> _userMembershipRepository;

        public AuthenticationService(IRepository<User> userRepository, IRepository<UserMembership> userMembershipRepository)
        {
            _userRepository = userRepository;
            _userMembershipRepository = userMembershipRepository;
        }

        public bool ValidateUser(string username, string password)
        {
            var user = _userRepository.FirstOrDefault(x => x.UserName.ToLower() == username.ToLower());
            return user != null && PasswordHash.ValidatePassword(password, user.Password);
        }

        public User CreateUser(string username, string password)
        {
            var newUser = new User {UserName = username, Password = PasswordHash.CreateHash(password)};
            var membership = new UserMembership { User = newUser, Role = Models.Entities.Role.User };

            _userRepository.Add(newUser);
            _userMembershipRepository.Add(membership);
            
            _userRepository.Flush();
            
            return newUser;
        }

        public void Login(string username, string password)
        {
            WebSecurity.Login(username, password);
        }

        public void Logout()
        {
            WebSecurity.Logout();
        }
    }
}
