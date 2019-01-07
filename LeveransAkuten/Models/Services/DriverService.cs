﻿using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Ads;
using LeveransAkuten.Models.ViewModels.Driver;
using Microsoft.EntityFrameworkCore;
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

        public async Task<DriverVm> GetDriverByUserName(string name)
        {
            BudAkutenUsers driver = await idctx.Users.Where(p => p.UserName == name).
                Select(d => new BudAkutenUsers
                {
                    Email = d.Email,
                    StreetAdress = d.StreetAdress,
                    ZipCode = d.ZipCode,
                    City = d.City,
                    PhoneNumber = d.PhoneNumber,
                    UserName = d.UserName,
                    ImageUrl = d.ImageUrl,
                    Id = d.Id
                })
                .SingleOrDefaultAsync();

            DriverVm driver2 = await appctx.Driver.Where(p => p.AspNetUsersId == driver.Id).
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

            driver2.Email = driver.Email;
            driver2.StreetAdress = driver.StreetAdress;
            driver2.ZipCode = driver.ZipCode;
            driver2.City = driver.City;
            driver2.PhoneNumber = driver.PhoneNumber;
            driver2.UserName = driver.UserName;
            driver2.ImageUrl = driver.ImageUrl;

            return driver2;
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
            
            var loggedInDriverId = GetDriverId(loggedInUser.Id);
            var indexVm = new DriverIndexVm();

            var allAds = await appctx.Ad.Where(d=>d.DriverId==loggedInDriverId).ToListAsync();
            indexVm.AdsNotStarted = allAds

                .Select(a => new DriverIndexAdVm { Header = a.Header, Id = a.Id, DriverId = a.DriverId, Start = a.StartDate.Date, End = a.EndDate})
                .ToList();


            return indexVm;
        }
        public int GetDriverId(string driverId)
        {
            var driver = appctx.Driver.FirstOrDefault(p => p.AspNetUsersId == driverId);
            var driverIdInt = driver.Id;
            return driverIdInt;
        }

        public async Task<AdsVm[]> GetAllAds()
        {
            var allAds = await appctx.Ad.ToArrayAsync();

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
