using AutoMapper;
using LeveransAkuten.Models.ClaimTypes;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Registration;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.Services
{
    public class RegistrationServices
    {
        IMapper mapper;
        UserManager<BudAkutenUsers> userManager;
        DbFirstContext appContext;

        public RegistrationServices(IMapper map, UserManager<BudAkutenUsers> userMan, DbFirstContext appCon)
        {
            userManager = userMan;
            mapper = map;
            appContext = appCon;
        }

        public async Task<IdentityResult> CreateCompanyAsync(CompanyRegVm companyVm)
        {
            var company = mapper.Map<BudAkutenUsers>(companyVm);
            var createResult = await userManager.CreateAsync(company, companyVm.Password);
            if (!createResult.Succeeded)
            {
                await userManager.DeleteAsync(company);
                return createResult;
            }
            var roleResult = await userManager.AddToRoleAsync(company, Roles.Company);
            if (!roleResult.Succeeded)
            {
                await userManager.DeleteAsync(company);
                return roleResult;
            }
            var userCompany = mapper.Map<Company>(companyVm);
            userCompany.AspNetUsersId = company.Id;
            await appContext.Company.AddAsync(userCompany);
            await appContext.SaveChangesAsync();
            return createResult;
        }

        public async Task<IdentityResult> CreateDriverAsync(DriverRegVm driverVm)
        {
            var driver = mapper.Map<BudAkutenUsers>(driverVm);
            var createResult = await userManager.CreateAsync(driver, driverVm.Password);
            if (!createResult.Succeeded)
            {
                await userManager.DeleteAsync(driver);
                return createResult;
            }
            var roleResult = await userManager.AddToRoleAsync(driver, Roles.Driver);
            if (!roleResult.Succeeded)
            {
                await userManager.DeleteAsync(driver);
                return roleResult;
            }
            var userDriver = mapper.Map<Driver>(driverVm);
            userDriver.AspNetUsersId = driver.Id;
            await appContext.Driver.AddAsync(userDriver);
            await appContext.SaveChangesAsync();
            return createResult;
        }
    }
}
