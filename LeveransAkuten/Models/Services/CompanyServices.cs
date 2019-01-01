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
        public async Task<List<CompanyIndexAdVm>> GetAdsNotStartedAsync(BudAkutenUsers loggedInUser)
        {
            var allAds = await dbContext.Ad.Where(a => a.UserId == loggedInUser.Id).ToListAsync();
            var ads = await allAds.Where( a => DateTime.Compare(a.StartDate, DateTime.Now) > 0).Select(p => new CompanyIndexAdVm {username = p.User.UserName }).ToListAsync();
                return ads;
        }
    }
}
