using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Company
{
    public class CompanyIndexVm
    {
        public List<CompanyIndexAdVm> AdsNotStarted { get; set; }
        public List<CompanyIndexAdVm> AdsActive { get; set; }
        public List<CompanyIndexAdVm> AdsFinished { get; set; }
    }
}
