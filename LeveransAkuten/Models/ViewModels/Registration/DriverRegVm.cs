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
        [Display(Name = "Användarnamn")]
        public string UserName { get; set; }

        [Required, MinLength(6)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [Required, Compare(nameof(Password))]
        [Display(Name = "Bekräfta lösenord")]
        public string ConfirmPassword { get; set; }
        
        [Required, MinLength(2)]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; } 
        
        [Required, MinLength(2)]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Födelsedatum")]
        public DateTime DateOfBirth { get; set; }

        [Required, EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Postort")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Gatuadress")]
        public string StreetAdress { get; set; }

        [Required]
        [Display(Name = "Postnummer")]
        public string ZipCode { get; set; }
        
        public bool A { get; set; } = false;
        public bool B { get; set; } = false;
        public bool C { get; set; } = false;
        public bool D { get; set; } = false;
        public bool CE { get; set; } = false;
    }
}
