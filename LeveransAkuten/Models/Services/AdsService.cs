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

        public AdsService(DbFirstContext Appctx)
        {
           
            this.appctx = Appctx;
        }
        public async Task AddAdsAsync(AdsVm ad)
        {
            var newAd = new Ad() { Header = ad.Header, Description = ad.Description, StartDate = ad.StartDate, EndDate = ad.EndDate, Arequired = ad.Arequired, Brequired = ad.Brequired, Cerequired = ad.Cerequired, Crequired = ad.Crequired, Drequired = ad.Drequired ,UserId=ad.UserId};
            await appctx.Ad.AddAsync(newAd);
            await appctx.SaveChangesAsync();

        }
        public async Task<List<Ad>> GetAllAdsAsync()
        {
            List<Ad> adsHeaders = await appctx.Ad.Select(c => c).ToListAsync();
            return adsHeaders;
        }
    }
}
