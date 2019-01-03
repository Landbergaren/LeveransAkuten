using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Driver;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.Services
{
    public class DriverServices
    {
        private readonly DbFirstContext dbContext;

        public DriverServices(DbFirstContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<DriverIndexVm> GetAdsNotStartedAsync(BudAkutenUsers loggedInUser)
        {

            var indexVm = new DriverIndexVm();

            var allAds = await dbContext.Ad.ToListAsync();
            indexVm.AdsNotStarted = allAds
                .Where(a => DateTime.Compare(a.StartDate, DateTime.Now) > 0)
                .Select(a => new DriverIndexAdVm { Header = a.Header, Id = a.Id })
                .ToList();
            indexVm.AdsActive = allAds
                .Where(a => (DateTime.Compare(a.StartDate, DateTime.Now) < 0) && (DateTime.Compare((DateTime)a.EndDate, DateTime.Now) > 0))
                .Select(a => new DriverIndexAdVm { Header = a.Header, Id = a.Id })
                .ToList();
            indexVm.AdsFinished = allAds
                .Where(a => DateTime.Compare((DateTime)a.EndDate, DateTime.Now) < 0)
                .Select(a => new DriverIndexAdVm { Header = a.Header, Id = a.Id })
                .ToList();
            return indexVm;
        }






    }
}
