using AutoMapper;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Ads;
using LeveransAkuten.Models.ViewModels.Registration;
using LeveransAkuten.Models.ViewModels.SearchDriver;

namespace LeveransAkuten.Helpers
{
    public class AutoMapperProfiles : Profile
    {

        public AutoMapperProfiles()
        {
            CreateMap<Ad, AdsVm>();
            CreateMap<Ad, EditAdsVm>();
            CreateMap<EditAdsVm, Ad>();
            CreateMap<CompanyRegVm, BudAkutenUsers>();
            CreateMap<DriverRegVm, BudAkutenUsers>();
            CreateMap<SearchDriverVm, BudAkutenUsers>();
            CreateMap<DriverRegVm, Driver>();
            CreateMap<CompanyRegVm, Company>();
            CreateMap<Ad, DetailsAdsVm>().ForMember(x => x.Booked, opt => opt.Ignore())
            .ForMember(dest => dest.CompanyName, opt =>
             {
                 opt.MapFrom(d => d.Company.CompanyName);
             })
            .ForMember(dest => dest.Booked, opt =>
             {
                 opt.MapFrom(d => d.DriverId != null);
             });

        }
    }
}
