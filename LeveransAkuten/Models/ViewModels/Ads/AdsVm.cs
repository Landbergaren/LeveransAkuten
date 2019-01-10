using LeveransAkuten.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Ads
{
    public class AdsVm
    {
        public int? DriverId { get; set; }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Rubrik")]         
        public string Header { get; set; }
        
        [Required]
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Startdatum")]       
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Slutdatum")]
        public DateTime EndDate { get; set; }
        
        [Display(Name = "A")]
        public bool Arequired { get; set; }
        [Display(Name = "B")]
        public bool Brequired { get; set; }
        [Display(Name = "C")]
        public bool Crequired { get; set; }
        [Display(Name = "D")]
        public bool Drequired { get; set; }
        [Display(Name = "CE")]
        public bool Cerequired { get; set; }
      
       
    }
}
