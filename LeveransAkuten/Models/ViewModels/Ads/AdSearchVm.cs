using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.ViewModels.Ads
{
    public class AdSearchVm
    {
        public AdsVm[] Ads { get; set; }
        public AdsVm Ad { get; set; }
    }
}
