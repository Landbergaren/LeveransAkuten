using LeveransAkuten.Models.Entities;
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
        BudIdentityContext _IdentityCtx;
        UserManager<BudAkutenUsers> userManager;

        public AccountService(BudIdentityContext IdentityCtx, UserManager<BudAkutenUsers> userMan)
        {
            _IdentityCtx = IdentityCtx;
            userManager = userMan;
        }

        public void BuildIdentityDb()
        {
            _IdentityCtx.Database.EnsureCreated();
        }

        public async Task<IdentityResult> AddNewUserAsync()
        {
            return await userManager.CreateAsync(new BudAkutenUsers { UserName = "TestPelle" }, "Password");
        }
    }
}
