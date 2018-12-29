using AutoMapper;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Registration;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.Services
{
    public class RegistrationService
    {
        IMapper mapper;
        UserManager<BudAkutenUsers> userManager;

        public RegistrationService(IMapper map, UserManager<BudAkutenUsers> userMan)
        {
            userManager = userMan;
            mapper = map;
        }

        public async Task<IdentityResult> CreateCompanyAsync(CompanyRegVm companyVm)
        {
            var company = mapper.Map<BudAkutenUsers>(companyVm);
            var createResult = await userManager.CreateAsync(company, companyVm.Password);
            if (!createResult.Succeeded)
                return createResult;
            var roleResult = await userManager.AddToRoleAsync(company, "Company");            
                return createResult;
        }
    }
}
