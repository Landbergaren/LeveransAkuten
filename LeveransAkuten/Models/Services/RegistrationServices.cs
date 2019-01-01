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

        public RegistrationServices(IMapper map, UserManager<BudAkutenUsers> userMan)
        {
            userManager = userMan;
            mapper = map;
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
            var roleResult = await userManager.AddToRoleAsync(company, "Company");       
            if (!roleResult.Succeeded)
            {
                await userManager.DeleteAsync(company);
                return roleResult;
            }
            await userManager.AddClaimAsync(company, new Claim(CompanyClaimTypes.CompanyName, companyVm.CompanyName));
            return createResult;
        }

        internal async Task<IdentityResult> CreateDriverAsync(DriverRegVm driverVm)
        {
            var driver = mapper.Map<BudAkutenUsers>(driverVm);
            var createResult = await userManager.CreateAsync(driver, driverVm.Password);
            if (!createResult.Succeeded)
            {
                await userManager.DeleteAsync(driver);
                return createResult;
            }
            var roleResult = await userManager.AddToRoleAsync(driver, "Driver");
            if (!roleResult.Succeeded)
            {
                await userManager.DeleteAsync(driver);
                return roleResult;
            }
            await userManager.AddClaimAsync(driver, new Claim(DriverClaimTypes.FirstName, driverVm.FirstName));
            await userManager.AddClaimAsync(driver, new Claim(DriverClaimTypes.LastName, driverVm.LastName));
            await userManager.AddClaimAsync(driver, new Claim(DriverClaimTypes.BirthDate, driverVm.BirthDate.ToString()));
            await userManager.AddClaimAsync(driver, new Claim(DriverClaimTypes.ALicense, driverVm.ALicense.ToString()));
            await userManager.AddClaimAsync(driver, new Claim(DriverClaimTypes.BLicense, driverVm.BLicense.ToString()));
            await userManager.AddClaimAsync(driver, new Claim(DriverClaimTypes.CLicense, driverVm.BLicense.ToString()));
            await userManager.AddClaimAsync(driver, new Claim(DriverClaimTypes.CELicense, driverVm.CELicense.ToString()));
            await userManager.AddClaimAsync(driver, new Claim(DriverClaimTypes.DLicense, driverVm.DLicense.ToString()));
            return createResult;
        }
    }
}
