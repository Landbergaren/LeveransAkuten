﻿using LeveransAkuten.Models.Entities;
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
    }
}
