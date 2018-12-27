using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models
{
    public class AccountService
    {
        IdentityDbContext _IdentityCtx;
        public AccountService(IdentityDbContext IdentityCtx)
        {
            _IdentityCtx = IdentityCtx;
        }


        public void BuildIdentityDb()
        {
            _IdentityCtx.Database.EnsureCreated();
        }
    }
}
