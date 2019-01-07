using LeveransAkuten.Models.Entities;
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
                    Image = d.Image,
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
            driver2.Image = driver.Image;

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
                    Image = d.Image
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
                    Id = a.Id,
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

        public async Task<AdsVm[]> FilterAds (AdsVm adRequest)
        {
            var allAds = await appctx.Ad.ToArrayAsync();
            List<AdsVm> filteredAds = new List<AdsVm>();

            foreach (var ad in allAds)
            {
                if(ad.Arequired && adRequest.Arequired ||
                    ad.Brequired && adRequest.Brequired ||
                    ad.Crequired && adRequest.Crequired ||
                    ad.Cerequired && adRequest.Cerequired ||
                    ad.Drequired && adRequest.Drequired
                    )
                {
                    filteredAds.Add(new AdsVm {
                        Id = ad.Id,
                        Header = ad.Header,
                        Arequired = ad.Arequired,
                        Brequired = ad.Brequired,
                        Crequired = ad.Crequired,
                        Cerequired = ad.Cerequired,
                        Description = ad.Description,
                        StartDate = ad.StartDate,
                        EndDate = ad.EndDate.Value
                    });
                }
            }
            return filteredAds.ToArray(); 
        }

        public async Task<DriverUpdateVm> GetDriverForUpdate(string name)
        {
            var driver = await GetDriverByUserName(name);
            DriverUpdateVm d = new DriverUpdateVm();

            d.A = driver.A;
            d.B = driver.B;
            d.C = driver.C;
            d.CE = driver.CE;
            d.D = driver.D;
            d.City = driver.City;
            d.Description = driver.Description;
            d.Email = driver.Email;
            d.FirstName = driver.FirstName;
            d.Id = driver.Id;
            d.Image = driver.Image;
            d.LastName = driver.LastName;
            d.PhoneNumber = driver.PhoneNumber;
            d.StreetAdress = driver.StreetAdress;
            d.UserName = driver.UserName;
            d.ZipCode = driver.ZipCode;

            return d;
        }

        public async Task UpdateDriver(DriverUpdateVm driver)
        {
            BudAkutenUsers d = await idctx.Users.Where(p => p.UserName == driver.UserName).SingleOrDefaultAsync();

            d.Email = driver.Email;
            d.StreetAdress = driver.StreetAdress;
            d.ZipCode = driver.ZipCode;
            d.City = driver.City;
            d.PhoneNumber = driver.PhoneNumber;
            d.UserName = driver.UserName;
            d.Image = driver.Image;

            var driver2 = await appctx.Driver.Where(p => p.AspNetUsersId == d.Id).SingleOrDefaultAsync();

            driver2.Description = driver.Description;
            driver2.A = driver.A;
            driver2.B = driver.B;
            driver2.C = driver.C;
            driver2.Ce = driver.CE;
            driver2.D = driver.D;
            driver2.FirstName = driver.FirstName;
            driver2.LastName = driver.LastName;

            await appctx.SaveChangesAsync();
            await idctx.SaveChangesAsync();
        }
    }
}

