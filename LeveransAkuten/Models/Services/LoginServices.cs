using LeveransAkuten.Models.ClaimTypes;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.Account;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace LeveransAkuten.Models
{
    public class LoginServices
    {
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
            if (!await roleManager.RoleExistsAsync(Roles.Company) && !await roleManager.RoleExistsAsync(Roles.Driver))
            {
                var companyRole = new IdentityRole();
                var driverRole = new IdentityRole();
                companyRole.Name = Roles.Driver;
                driverRole.Name = Roles.Company;
                await roleManager.CreateAsync(companyRole);
                await roleManager.CreateAsync(driverRole);
            }
        }

        public async Task<SignInResult> LoginUserAsync(LoginVm loginVm)
        {
            var result = await signInManager.PasswordSignInAsync(loginVm.Username, loginVm.Password, false, false);
            var roles = await userManager.GetRolesAsync(await userManager.FindByNameAsync(loginVm.Username));
            return result;
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }


    }
}
