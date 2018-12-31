using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Registration
{
    public class DriverRegVm
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public bool ALicense { get; set; } = false;
        public bool BLicense { get; set; } = false;
        public bool CLicense { get; set; } = false;
        public bool DLicense { get; set; } = false;
        public bool CELicense { get; set; } = false;
    }
}
