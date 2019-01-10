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
        [Display(Name = "Användarnamn")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Obligatoriskt"), MinLength(6, ErrorMessage = "Minst sex bokstäver")]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        [Required, Compare(nameof(Password))]
        [Display(Name = "Bekräfta lösenord")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Obligatoriskt"), MinLength(2, ErrorMessage = "Minst två bokstäver")]
        [Display(Name = "Företagsnamn")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Obligatoriskt"), MinLength(5, ErrorMessage = "Minst två bokstäver")]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Obligatoriskt")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obligatoriskt"), MinLength(2, ErrorMessage = "Minst två bokstäver")]
        [Display(Name = "Gatuadress")]
        public string StreetAdress { get; set; }

        [Required(ErrorMessage = "Obligatoriskt")]
        [MinLength(2, ErrorMessage = "Minst två bokstäver")]
        [Display(Name = "Postort")]
        public string City { get; set; }

        [Required(ErrorMessage = "Obligatoriskt")]
        [MinLength(4, ErrorMessage = "Minst fyra bokstäver")]
        [Display(Name = "Postnummer")]
        public string ZipCode { get; set; }
    }
}
