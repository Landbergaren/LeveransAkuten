using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Company;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.Services
{
    public class CompanyServices
    {
        DbFirstContext dbContext;
        UserManager<BudAkutenUsers> userManager;
        public CompanyServices(DbFirstContext dbCtx, UserManager<BudAkutenUsers> userMan)
        {
            dbContext = dbCtx;
            userManager = userMan;
        }
        public async Task<CompanyIndexVm> GetAdsNotStartedAsync(BudAkutenUsers loggedInUser)
        {
            var indexVm = new CompanyIndexVm();
            var allAds = await dbContext.Ad.Where(a => a.UserId == loggedInUser.Id).ToListAsync();
            indexVm.AdsNotStarted = allAds
                .Where( a => DateTime.Compare(a.StartDate, DateTime.Now) > 0)
                .Select(a => new CompanyIndexAdVm {username = a.User.UserName })
                .ToList();
            indexVm.AdsActive = allAds
                .Where(a => (DateTime.Compare(a.StartDate, DateTime.Now) < 0) && (DateTime.Compare((DateTime)a.EndDate, DateTime.Now) > 0))
                .Select(a => new CompanyIndexAdVm { username = a.User.UserName })
                .ToList();
            indexVm.AdsFinished = allAds
                .Where(a => DateTime.Compare((DateTime)a.EndDate, DateTime.Now) < 0)
                .Select(a => new CompanyIndexAdVm { username = a.User.UserName })
                .ToList();
                return indexVm;
        }
    }
}
