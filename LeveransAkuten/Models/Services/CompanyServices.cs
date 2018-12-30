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
            var ads = await dbContext.Ad.Include(o => o.User).Where( a => DateTime.Compare(a.StartDate, DateTime.Now) > 0).Select(p => new CompanyIndexAdVm { Header = p.Header, username = p.User.UserName }).ToListAsync();
                return ads;
        }
    }
}
