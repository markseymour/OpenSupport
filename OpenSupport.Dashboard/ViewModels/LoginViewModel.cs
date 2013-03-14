using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenSupport.Models.Entities;

namespace OpenSupport.Dashboard.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Username required")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "Password required")]
        public String Password { get; set; }
        public Boolean RememberMe { get; set; }
    }
}
