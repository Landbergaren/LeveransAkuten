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
        public async Task<CompanyIndexAdVm> GetAdsNotStartedAsync(BudAkutenUsers loggedInUser)
        {
            var ads = await dbContext.Ad.Include(o => o.User).Select(p => new CompanyIndexAdVm { Header = p.Header, username = p.User.UserName }).ToListAsync();
                return new CompanyIndexAdVm();
        }
    }
}
