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
    public class AccountService
    {
        BudIdentityContext identityCtx;
        UserManager<BudAkutenUsers> userManager;
        SignInManager<BudAkutenUsers> signInManager;

        public AccountService(BudIdentityContext identCtx, UserManager<BudAkutenUsers> userMan, SignInManager<BudAkutenUsers> signInMan)
        {
            identityCtx = identCtx;
            userManager = userMan;
            signInManager = signInMan;

        }

        public void BuildIdentityDb()
        {
            identityCtx.Database.EnsureCreated();
        }

        public async Task<IdentityResult> AddNewUserAsync()
        {
            return await userManager.CreateAsync(new BudAkutenUsers { UserName = "testpelle" }, "Password");
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
