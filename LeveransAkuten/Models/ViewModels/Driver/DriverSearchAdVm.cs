using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Driver
{
    public class DriverSearchAdVm
    {
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
