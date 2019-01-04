using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Ads;
using LeveransAkuten.Models.ViewModels.Driver;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.Services
{
    public class DriverService
    {
        private readonly DbFirstContext appctx;
        private readonly BudIdentityContext idctx;

        public DriverService(DbFirstContext appctx, BudIdentityContext idctx)
        {
            this.appctx = appctx;
            this.idctx = idctx;
        }

        public async Task<DriverVm> GetDriverByIdAsync(string id)
        {
            DriverVm driver = await idctx.Users.Where(p => p.Id == id).
                Select(d => new DriverVm
                {
                    Email = d.Email,
                    StreetAdress = d.StreetAdress,
                    ZipCode = d.ZipCode,
                    City = d.City,
                    PhoneNumber = d.PhoneNumber,
                    UserName = d.UserName,
                    ImageUrl = d.ImageUrl
                })
                .SingleOrDefaultAsync();

            DriverVm driver2 = await appctx.Driver.Where(p => p.AspNetUsersId == id).
                Select(d => new DriverVm
                {
                    Description = d.Description,
                    A = d.A,
                    B = d.B,
                    C = d.C,
                    CE = d.Ce,
                    D = d.D,
                    FirstName = d.FirstName,
                    LastName = d.LastName
                })
                .SingleOrDefaultAsync();

            driver.Description = driver2.Description;
            driver.A = driver2.A;
            driver.B = driver2.B;
            driver.C = driver2.C;
            driver.CE = driver2.CE;
            driver.D = driver2.D;
            driver.FirstName = driver2.FirstName;
            driver.LastName = driver2.LastName;

            return driver;
        }

        public async Task<DriverIndexVm> GetAdsNotStartedAsync(BudAkutenUsers loggedInUser)
        {

            var indexVm = new DriverIndexVm();

            var allAds = await appctx.Ad.ToListAsync();
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

        public async Task<AdsVm[]> GetAllAds ()
        {
            var allAds = await appctx.Ad.ToArrayAsync();

            //AdsVm[] ads = new AdsVm[allAds.Length];

            //for(int i = 0; i < allAds.Length; i++)
            //{
            //    ads[i].Header = allAds[i].Header;
            //    ads[i].Arequired = allAds[i].Arequired;
            //    ads[i].Brequired = allAds[i].Brequired;
            //    ads[i].Cerequired = allAds[i].Crequired;
            //    ads[i].Crequired = allAds[i].Crequired;
            //    ads[i].Description = allAds[i].Description;
            //    ads[i].StartDate = allAds[i].StartDate;
            //    ads[i].EndDate = allAds[i].StartDate;
            //}



            //return ads;

            var ads = allAds.Select
                (a => new AdsVm
                {
                    Header = a.Header,
                    Arequired = a.Arequired,
                    Brequired = a.Brequired,
                    Crequired = a.Crequired,
                    Cerequired = a.Cerequired,
                    Description = a.Description,
                    StartDate = a.StartDate,
                    EndDate = a.EndDate.Value

                });

            return ads.ToArray();
        }
    }
}
