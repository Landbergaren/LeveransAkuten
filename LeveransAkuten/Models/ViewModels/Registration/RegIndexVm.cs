using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Registration
{
    public class RegIndexVm
    {
        public RegIndexVm()
        {
        }
        public DriverRegVm Driver { get; set; }
        public CompanyRegVm Company { get; set; }
        public IEnumerable<string> ErrorMsges { get; set; }
    }
}
