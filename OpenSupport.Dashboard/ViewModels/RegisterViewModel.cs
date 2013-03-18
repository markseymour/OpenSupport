using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenSupport.Dashboard.ViewModels
{
    public class RegisterViewModel
    {
        public String ReturnUrl { get; set; }

        [Required(ErrorMessage="Username required")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "Password required")]
        public String Password { get; set; }
        public String ConfirmPassword { get; set; }
    }
}
