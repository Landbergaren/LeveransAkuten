using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Registration
{
    public class DriverRegVm
    {
        [Required]
        [MinLength(6)]
        public string UserName { get; set; }
        [Required, MinLength(6)]
        public string Password { get; set; }
        [Required, Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }        
        [Required, MinLength(2)]
        public string FirstName { get; set; }        
        [Required, MinLength(2)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string City { get; set; }
        public bool ALicense { get; set; } = false;
        public bool BLicense { get; set; } = false;
        public bool CLicense { get; set; } = false;
        public bool DLicense { get; set; } = false;
        public bool CELicense { get; set; } = false;
    }
}
