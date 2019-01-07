using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Driver
{
    public class DriverUpdateVm
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public bool A { get; set; }
        public bool B { get; set; }
        public bool C { get; set; }
        public bool D { get; set; }
        public bool CE { get; set; }

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
        public DateTime DateOfBirth { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string StreetAdress { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [MaxLength(450, ErrorMessage = "Obs! Max 450 tecken")]
        public string Description { get; set; }
    }
}
