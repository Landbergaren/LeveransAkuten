using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Company
{
    public class CompanyUpdateVm
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }

        [Required(ErrorMessage = "Obligatoriskt"), MinLength(3, ErrorMessage = "Minst tre bokstäver")]
        [Display(Name = "Användarnamn")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Obligatoriskt"), MinLength(6, ErrorMessage = "Minst sex bokstäver")]
        [Display(Name = "Lösenord")]
        
        public string Password { get; set; }

        [Required, Compare(nameof(Password))]
        [Display(Name = "Bekräfta Lösenord")]
     
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Obligatoriskt"), MinLength(2, ErrorMessage = "Minst två bokstäver")]
        [Display(Name = "Företagsnamn")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Obligatoriskt"), MinLength(5, ErrorMessage = "Minst två bokstäver")]
        [Display(Name = "Telefonnummer")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Obligatoriskt")]
        [Display(Name = "E-post")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Obligatoriskt"), MinLength(2, ErrorMessage = "Minst två bokstäver")]
        [Display(Name = "Gatuadress")]
        public string StreetAddress { get; set; }

        [Required(ErrorMessage = "Obligatoriskt")]
        [MinLength(2, ErrorMessage = "Minst två bokstäver")]
        [Display(Name = "Stad")]
        public string City { get; set; }

        [Required(ErrorMessage = "Obligatoriskt")]
        [MinLength(4, ErrorMessage = "Minst fyra bokstäver")]
        [Display(Name = "Postnummer")]
        public string ZipCode { get; set; }

        [MaxLength(450, ErrorMessage = "Obs! Max 450 tecken")]
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
    }
}
