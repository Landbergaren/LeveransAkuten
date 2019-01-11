using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Driver
{
    public class CompanyDetailsVm
    {
        public int CompanyId { get; set; }        
        [Display(Name = "Företag")]
        public string CompanyName { get; set; }

        [Display(Name = "E-post")]
        public string Email { get; set; }

        [Display(Name = "Gatuadress")]
        public string StreetAdress { get; set; }

        [Display(Name = "Postnummer")]
        public string ZipCode { get; set; }

        [Display(Name = "Stad")]
        public string City { get; set; }

        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        public string Description { get; set; }
        public byte[] Image { get; set; }
    }
}
