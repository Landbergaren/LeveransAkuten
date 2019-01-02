using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Account
{
    public class LoginVm
    {
        [Required, MinLength(6)]
        public string Username { get; set; }
        [Required, MinLength(6)]
        public string Password { get; set; }
        public string ErrorMsg { get; set; }
        public string ReturnUrl { get; set; }
    }
}
