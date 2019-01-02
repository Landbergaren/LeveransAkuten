using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Company;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
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
            var usersCompanyId = dbContext.Company.Where(c => c.AspNetUsersId == loggedInUser.Id).Select(c => c.Id).FirstOrDefault();
            var allAds = await dbContext.Ad.Where(a => a.CompanyId == usersCompanyId).ToListAsync();
            indexVm.AdsNotStarted = allAds
                .Where(a => DateTime.Compare(a.StartDate, DateTime.Now) > 0)
                .Select(a => new CompanyIndexAdVm { Header = a.Header, Id = a.Id })
                .ToList();
            indexVm.AdsActive = allAds
                .Where(a => (DateTime.Compare(a.StartDate, DateTime.Now) < 0) && (DateTime.Compare((DateTime)a.EndDate, DateTime.Now) > 0))
                .Select(a => new CompanyIndexAdVm { Header = a.Header, Id = a.Id })
                .ToList();
            indexVm.AdsFinished = allAds
                .Where(a => DateTime.Compare((DateTime)a.EndDate, DateTime.Now) < 0)
                .Select(a => new CompanyIndexAdVm { Header = a.Header, Id = a.Id })
                .ToList();
            return indexVm;
        }
    }
}
