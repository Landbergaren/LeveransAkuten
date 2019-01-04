﻿using LeveransAkuten.Models.Entities;
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
        private readonly DbFirstContext dbContext;
        private readonly BudIdentityContext idctx;
        UserManager<BudAkutenUsers> userManager;

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
                    ImageUrl = d.ImageUrl
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
            BudAkutenUsers company = await idctx.Users.Where(p => p.UserName == name).
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

            CompanyVm company2 = await dbContext.Company.Where(p => p.AspNetUsersId == company.Id).
                Select(d => new CompanyVm
                {
                    Description = d.Description
                })
                .SingleOrDefaultAsync();

            company2.Email = company.Email;
            company2.StreetAdress = company.StreetAdress;
            company2.ZipCode = company.ZipCode;
            company2.City = company.City;
            company2.PhoneNumber = company.PhoneNumber;
            company2.UserName = company.UserName;
            company2.ImageUrl = company.ImageUrl;

            return company2;
        }

    }
}
