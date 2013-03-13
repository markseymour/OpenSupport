using System;

namespace OpenSupport.Models
{
    public interface IUser
    {
        String UserName { get; set; }
        String Email { get; set; }
        String Password { get; set; }
    }
}
