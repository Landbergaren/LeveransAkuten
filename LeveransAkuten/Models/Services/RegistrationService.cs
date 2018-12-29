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

        public async Task CreateCompanyAsync(CompanyRegVm companyVm)
        {
            var company = mapper.Map<BudAkutenUsers>(companyVm);
            await userManager.CreateAsync(company, companyVm.Password);
        }
    }
}
