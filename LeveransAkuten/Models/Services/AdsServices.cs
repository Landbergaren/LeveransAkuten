using AutoMapper;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Ads;
using LeveransAkuten.Models.ViewModels.Company;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace LeveransAkuten.Models.Services
{
    public class AdsServices
    {
        private readonly DbFirstContext appCtx;
        private readonly IMapper mapper;
        private readonly UserManager<BudAkutenUsers> userManager;

        public AdsServices(DbFirstContext Appctx, IMapper mapper, UserManager<BudAkutenUsers> userManager)
        {
            this.appCtx = Appctx;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task AddAdsAsync(CompanyCreateAdVm ad, string id)
        {
            Company com = appCtx.Company.FirstOrDefault(c => c.AspNetUsersId == id);
            var newAd = new Ad() { Header = ad.Header, Description = ad.Description, StartDate = ad.StartDate, EndDate = ad.EndDate, Arequired = ad.Arequired, Brequired = ad.Brequired, Cerequired = ad.Cerequired, Crequired = ad.Crequired, Drequired = ad.Drequired, Company = com };
            await appCtx.Ad.AddAsync(newAd);
            await appCtx.SaveChangesAsync();
        }

        public Ad GetAdsAsync()
        {
            Ad adsHeaders = appCtx.Ad.SingleOrDefault();
            return adsHeaders;
        }

        public async Task<Ad> GetUserAdAsync(int id)
        {
            var ad = await appCtx.Ad.FirstOrDefaultAsync(u => u.Id == id);
            //var adVm = mapper.Map<EditAdsVm>(ad);
            return ad;
        }

        public async Task EditAdsAsync(EditAdsVm ad)
        {
            var dbAd = await appCtx.Ad.FindAsync(ad.Id);
            mapper.Map(ad, dbAd);
            await appCtx.SaveChangesAsync();
        }

        public async Task RemoveAdAsync(int id)
        {
            appCtx.Ad.Remove(new Ad() { Id = id });
            await appCtx.SaveChangesAsync();
        }

        public async Task<DetailsAdsVm> GetAdDetailsAsync(int id)
        {
            var adVm = await appCtx.Ad.Include(a => a.Company).Select(a => mapper.Map<DetailsAdsVm>(a)).FirstOrDefaultAsync(u => u.Id == id);
            return adVm;
        }

        public async Task<bool> CheckIfAdIsFree(int id)
        {
            var IsFree = await appCtx.Ad.Where(a => a.Id == id).Select(a => a.DriverId == null).FirstOrDefaultAsync();
            return IsFree;
        }

        internal async Task AddDriverToAd(int addId, int driverIdInt)
        {
            var ad = await appCtx.Ad.Where(a => a.Id == addId).FirstOrDefaultAsync();
            ad.DriverId = driverIdInt;
            await appCtx.SaveChangesAsync();
        }
    }
}
