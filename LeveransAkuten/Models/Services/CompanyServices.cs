using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Company;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.Services
{
    public class CompanyServices
    {
        private readonly DbFirstContext dbContext;

        UserManager<BudAkutenUsers> userManager;
        private readonly BudIdentityContext idctx;

        public CompanyServices(DbFirstContext dbCtx, UserManager<BudAkutenUsers> userMan, BudIdentityContext idctx)
        {
            dbContext = dbCtx;
            userManager = userMan;
            this.idctx = idctx;
        }

        public async Task<CompanyIndexVm> GetAdsNotStartedAsync(BudAkutenUsers loggedInUser)
        {
            var indexVm = new CompanyIndexVm();
            var usersCompanyId = dbContext.Company.Where(c => c.AspNetUsersId == loggedInUser.Id).Select(c => c.Id).FirstOrDefault();
            var allAds = await dbContext.Ad.Where(a => a.CompanyId == usersCompanyId).ToListAsync();
            indexVm.AdsNotStarted = allAds
                .Where(a => DateTime.Compare(a.StartDate, DateTime.Now) > 0)
                .Select(a => new CompanyIndexAdVm { Header = a.Header, Id = a.Id, DriverId = a.DriverId, Start = a.StartDate.Date, End = a.EndDate })
                .ToList();
            indexVm.AdsActive = allAds
                .Where(a => (DateTime.Compare(a.StartDate, DateTime.Now) < 0) && (DateTime.Compare((DateTime)a.EndDate, DateTime.Now) > 0))
                .Select(a => new CompanyIndexAdVm { Header = a.Header, Id = a.Id, DriverId = a.DriverId, Start = a.StartDate.Date, End = a.EndDate })
                .ToList();
            indexVm.AdsFinished = allAds
                .Where(a => DateTime.Compare((DateTime)a.EndDate, DateTime.Now) < 0)
                .Select(a => new CompanyIndexAdVm { Header = a.Header, Id = a.Id, DriverId = a.DriverId, Start = a.StartDate.Date, End = a.EndDate })
                .ToList();
            return indexVm;
        }

        public async Task<CompanyVm> GetCompanyById(string id)
        {
            CompanyVm company = await idctx.Users.Where(p => p.Id == id).
                Select(d => new CompanyVm
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

            CompanyVm company2 = await dbContext.Company.Where(p => p.AspNetUsersId == id).
                Select(d => new CompanyVm
                {
                    Description = d.Description
                })
                .SingleOrDefaultAsync();

            company.Description = company2.Description;

            return company;
        }

        public async Task<CompanyVm> GetCompanyByName(string name)
        {
            BudAkutenUsers companyUser = await idctx.Users.Where(p => p.UserName == name).
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

            CompanyVm companyVm = await dbContext.Company.Where(p => p.AspNetUsersId == companyUser.Id).
                Select(d => new CompanyVm
                {
                    Description = d.Description,
                    CompanyName = d.CompanyName
                })
                .SingleOrDefaultAsync();

            companyVm.Email = companyUser.Email;
            companyVm.StreetAdress = companyUser.StreetAdress;
            companyVm.ZipCode = companyUser.ZipCode;
            companyVm.City = companyUser.City;
            companyVm.PhoneNumber = companyUser.PhoneNumber;
            companyVm.UserName = companyUser.UserName;
            companyVm.Image = companyUser.Image;

            return companyVm;
        }

        public async Task<CompanyUpdateVm> GetCompanyForUpdate(string name)
        {
            var company = await GetCompanyByName(name);
            CompanyUpdateVm c = new CompanyUpdateVm();

            c.City = company.City;
            c.Description = company.Description;
            c.Email = company.Email;
            c.Image = company.Image;
            c.PhoneNumber = company.PhoneNumber;
            c.StreetAddress = company.StreetAdress;
            c.UserName = company.UserName;
            c.ZipCode = company.ZipCode;
            c.CompanyName = company.CompanyName;

            return c;
        }

        public async Task UpdateCompanyAsync(CompanyUpdateVm company)
        {
            BudAkutenUsers c = await idctx.Users.Where(o => o.UserName == company.UserName).SingleOrDefaultAsync();

            c.Email = company.Email;
            c.StreetAdress = company.StreetAddress;
            c.ZipCode = company.ZipCode;
            c.City = company.City;
            c.PhoneNumber = company.PhoneNumber;
            c.UserName = company.UserName;


            var company2 = await dbContext.Company.Where(o => o.AspNetUsersId == c.Id).SingleOrDefaultAsync();

            company2.Description = company.Description;
            company2.CompanyName = company.CompanyName;

            await dbContext.SaveChangesAsync();
            await idctx.SaveChangesAsync();
        }

        public async Task UploadImage(string userName, IFormFile Image)
        {
            BudAkutenUsers d = await idctx.Users.Where(p => p.UserName == userName).SingleOrDefaultAsync();

            using (var ms = new MemoryStream())
            {
                Image.CopyTo(ms);
                d.Image = ms.ToArray();
            }

            await idctx.SaveChangesAsync();
        }
    }
}
