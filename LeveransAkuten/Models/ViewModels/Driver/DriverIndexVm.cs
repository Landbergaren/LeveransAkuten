using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Driver
{
    public class DriverIndexVm
    {

        public List<DriverIndexAdVm> AdsNotStarted { get; set; }
        public List<DriverIndexAdVm> AdsActive { get; set; }
        public List<DriverIndexAdVm> AdsFinished { get; set; }
    }
}
