using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models
{
    public class CreateAdVM
    {
        [Display(Name = "Rubrik")]
        [Required(ErrorMessage = "Du måste ange en rubrik.")]
        public string Header { get; set; }

        [Display(Name = "Info om uppdraget.")]
        [Required(ErrorMessage = "Du måste ange en information om uppdraget.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Du måste ange ett startdatum.")]
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public bool ARequired { get; set; }
        public bool BRequired { get; set; }
        public bool CRequired { get; set; }
        public bool DRequired { get; set; }
        public bool CERequired { get; set; }
    }
}
