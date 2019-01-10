using System;
using System.ComponentModel.DataAnnotations;

namespace LeveransAkuten.Models.ViewModels.Company
{
    public class CompanyIndexAdVm
    {
        public int? DriverId { get; set; }
        public int Id { get; set; }
        [Display(Name = "Rubrik")]
        public string Header { get; set; }
        [Display(Name = "Startdatum")]
        public DateTime Start { get; set; }
        [Display(Name = "Slutdatum")]
        public DateTime? End { get; set; }
        public byte[] Image { get; set; }
    }
}