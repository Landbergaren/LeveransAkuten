using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models
{
    public class LoginServices
    {
        private const string DRIVER_ROLE = "Driver";
        private const string COMPANY_ROLE = "Company";
        BudIdentityContext identityCtx;
        UserManager<BudAkutenUsers> userManager;
        SignInManager<BudAkutenUsers> signInManager;
        RoleManager<IdentityRole> roleManager;

        public LoginServices(BudIdentityContext identCtx, UserManager<BudAkutenUsers> userMan, SignInManager<BudAkutenUsers> signInMan, RoleManager<IdentityRole> rolMan)
        {
            identityCtx = identCtx;
            userManager = userMan;
            signInManager = signInMan;
            roleManager = rolMan;
        }

        public void BuildIdentityDb()
        {
            identityCtx.Database.EnsureCreated();
        }

        public async Task IfNotExistCreateRolesAsync()
        {
            if (!await roleManager.RoleExistsAsync(COMPANY_ROLE) && !await roleManager.RoleExistsAsync(DRIVER_ROLE))
            {
                var companyRole = new IdentityRole();
                var driverRole = new IdentityRole();
                companyRole.Name = COMPANY_ROLE;
                driverRole.Name = DRIVER_ROLE;
                await roleManager.CreateAsync(companyRole);
                await roleManager.CreateAsync(driverRole);
            }
        }

        public async Task<SignInResult> LoginUserAsync(LoginVm loginVm)
        {
            var result = await signInManager.PasswordSignInAsync(loginVm.Username, loginVm.Password, false, false);
            return result;
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }
    }
}
