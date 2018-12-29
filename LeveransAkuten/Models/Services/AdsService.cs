using AutoMapper;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Ads;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LeveransAkuten.Models.Services
{
    public class AdsService
    {
        private readonly DbFirstContext appctx;
        private readonly IMapper mapper;

        public AdsService(DbFirstContext Appctx, IMapper mapper)
        {
           
            this.appctx = Appctx;
            this.mapper = mapper;
        }
        public async Task AddAdsAsync(AdsVm ad)
        {
            var newAd = new Ad() { Header = ad.Header, Description = ad.Description, StartDate = ad.StartDate, EndDate = ad.EndDate, Arequired = ad.Arequired, Brequired = ad.Brequired, Cerequired = ad.Cerequired, Crequired = ad.Crequired, Drequired = ad.Drequired /*,UserId=ad.UserId*/};
            await appctx.Ad.AddAsync(newAd);
            await appctx.SaveChangesAsync();

        }
        public Ad GetAdsAsync()
        {
           
            Ad adsHeaders =  appctx.Ad.SingleOrDefault();
            return adsHeaders;
        }
    }
}
