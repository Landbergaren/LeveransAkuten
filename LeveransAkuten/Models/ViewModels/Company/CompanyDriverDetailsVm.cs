using System.ComponentModel.DataAnnotations;

namespace LeveransAkuten.Models.ViewModels.Company
{
    public class CompanyDriverDetailsVm
    {
        public int Id { get; set; }
        [Display(Name = "Användarnamn")]
        public string UserName { get; set; }
        [Display(Name = "E-post")]

        public string Email { get; set; }
        [Display(Name = "Gatuadress")]
        public string StreetAdress { get; set; }
        [Display(Name = "Postnummer")]

        public string ZipCode { get; set; }
        [Display(Name = "Stad")]
        public string City { get; set; }
        [Display(Name = "A")]
        public bool A { get; set; }
        [Display(Name = "B")]
        public bool B { get; set; }
        [Display(Name = "C")]
        public bool C { get; set; }
        [Display(Name = "D")]
        public bool D { get; set; }
        [Display(Name = "CE")]
        public bool CE { get; set; }
        [Display(Name = "Telefonnummer")]


        public string PhoneNumber { get; set; }
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
    }
}
