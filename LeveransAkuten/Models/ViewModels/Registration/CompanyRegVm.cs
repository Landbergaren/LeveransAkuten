using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Registration
{
    public class CompanyRegVm
    {
        [Required (ErrorMessage = "Obligatoriskt"), MinLength(3, ErrorMessage = "Minst tre bokstäver")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Obligatoriskt"), MinLength(6, ErrorMessage = "Minst sex bokstäver")]
        public string Password { get; set; }

        [Required, Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Obligatoriskt"), MinLength(2, ErrorMessage = "Minst två bokstäver")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Obligatoriskt"), MinLength(5, ErrorMessage = "Minst två bokstäver")]
        
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Obligatoriskt")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obligatoriskt"), MinLength(2, ErrorMessage = "Minst två bokstäver")]
        public string StreetAdress { get; set; }

        [Required(ErrorMessage = "Obligatoriskt")]
        [MinLength(2, ErrorMessage = "Minst två bokstäver")]
        public string City { get; set; }

        [Required(ErrorMessage = "Obligatoriskt")]
        [MinLength(4, ErrorMessage = "Minst fyra bokstäver")]
        public string ZipCode { get; set; }
    }
}
