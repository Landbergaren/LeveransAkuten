using AutoMapper;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Ads;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace LeveransAkuten.Models.Services
{
    public class AdsService
    {
        private readonly DbFirstContext appctx;
        private readonly IMapper mapper;
        private readonly BudIdentityContext identCtx;
        private readonly UserManager<BudAkutenUsers> userMan;
        private readonly SignInManager<BudAkutenUsers> signInMan;
    

        public AdsService(DbFirstContext Appctx, IMapper mapper,BudIdentityContext identCtx,UserManager<BudAkutenUsers> userMan, SignInManager<BudAkutenUsers> signInMan)
        {
           
            this.appctx = Appctx;
            this.mapper = mapper;
            this.identCtx = identCtx;
            this.userMan = userMan;
            this.signInMan = signInMan;
            
        }
        public async Task AddAdsAsync(AdsVm ad,string id )
        {
            var newAd = new Ad() { Header = ad.Header, Description = ad.Description, StartDate = ad.StartDate, EndDate = ad.EndDate, Arequired = ad.Arequired, Brequired = ad.Brequired, Cerequired = ad.Cerequired, Crequired = ad.Crequired, Drequired = ad.Drequired ,UserId= id };
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
