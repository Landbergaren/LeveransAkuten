using AutoMapper;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LeveransAkuten.Models.Services
{
    public class AdsServices
    {
        private readonly DbFirstContext appctx;
        private readonly IMapper mapper;



        public AdsServices(DbFirstContext Appctx, IMapper mapper)
        {

            this.appctx = Appctx;
            this.mapper = mapper;


        }
        public async Task AddAdsAsync(AdsVm ad, string id)
        {
            Company com = appctx.Company.FirstOrDefault(c => c.AspNetUsersId == id);
            var newAd = new Ad() { Header = ad.Header, Description = ad.Description, StartDate = ad.StartDate, EndDate = ad.EndDate, Arequired = ad.Arequired, Brequired = ad.Brequired, Cerequired = ad.Cerequired, Crequired = ad.Crequired, Drequired = ad.Drequired, Company = com };
            await appctx.Ad.AddAsync(newAd);
            await appctx.SaveChangesAsync();


        }
        public Ad GetAdsAsync()
        {

            Ad adsHeaders = appctx.Ad.SingleOrDefault();
            return adsHeaders;
        }
        //public List<Ad> GetUserAds(string userId)
        //{

        //    List<Ad> adsList = appctx.Ad.Where(U => U.UserId == userId).Select(U => U).ToList();
        //    return adsList;
        //}
        public Ad GetUserAd(int id)
        {

            Ad ad = appctx.Ad.FirstOrDefault(u => u.Id == id);
            return ad;
        }
        public async Task EditAdsAsync(EditAdsVm ad)
        {

            var dbAd = await appctx.Ad.FindAsync(ad.Id);
            mapper.Map(ad, dbAd);
            await appctx.SaveChangesAsync();
        }

        public async Task RemoveAd(int id)
        {

            appctx.Ad.Remove(new Ad() { Id = id }); 
            await appctx.SaveChangesAsync();
        }

        public Ad GetAdDetails(int id)
        {
            var AdDetails =  GetUserAd(id);

            return AdDetails;
        }
    }
}
