using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Account
{
    public class LoginVm
    {
        [Required, MinLength(3)]
        public string Username { get; set; }
        [DataType(DataType.Password), Required, MinLength(3)]
        public string Password { get; set; }
        public string ErrorMsg { get; set; }
        public string ReturnUrl { get; set; }
    }
}
