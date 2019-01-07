using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Driver
{
    public class DriverIndexAdVm
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public int? DriverId { get; set; }
      

    }
}
