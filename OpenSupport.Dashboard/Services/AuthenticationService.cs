using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSupport.Core.Models;
using OpenSupport.DataAccess.Tools;
using OpenSupport.Models.Entities;
using System.Security.Cryptography;

namespace OpenSupport.Dashboard.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IRepository<User> _userRepository;

        public AuthenticationService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ValidateUser(string username, string password)
        {
            var user = _userRepository.Fetch(x => x.UserName.ToLower() == username.ToLower()).FirstOrDefault();
            return user != null && PasswordHash.ValidatePassword(password, user.Password);
        }

        public User CreateUser(string username, string password, string fullname)
        {
            var newUser = new User {UserName = username, Password = PasswordHash.CreateHash(password)};
            _userRepository.Add(newUser);
            return newUser;
        }
    }
}
