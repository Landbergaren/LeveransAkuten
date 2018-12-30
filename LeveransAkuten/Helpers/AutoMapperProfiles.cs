using AutoMapper;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Ads;
using LeveransAkuten.Models.ViewModels.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Helpers
{
    public class AutoMapperProfiles: Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<Ad, AdsVm>();
            CreateMap<Ad, EditAdsVm>();
            CreateMap<EditAdsVm, Ad>();
            CreateMap<CompanyRegVm, BudAkutenUsers>();
            CreateMap<DriverRegVm, BudAkutenUsers>();
        }
    }
}
