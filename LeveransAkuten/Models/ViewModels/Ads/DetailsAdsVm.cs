using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Ads
{
    public class DetailsAdsVm
    {
        public int Id { get; set; }
        [Required]

        public string Header { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]

        public DateTime EndDate { get; set; }

        public bool Arequired { get; set; }
        public bool Brequired { get; set; }
        public bool Crequired { get; set; }
        public bool Drequired { get; set; }
        public bool Cerequired { get; set; }

        public bool Booked { get; set; }
    }
}
