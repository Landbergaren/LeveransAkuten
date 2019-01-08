using LeveransAkuten.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.Services
{
    public class HomeService
    {
        BudIdentityContext identityCtx;

        public HomeService(BudIdentityContext identityCtx)
        {
            this.identityCtx = identityCtx;
        }

        public void BuildIdentityDb()
        {
            identityCtx.Database.EnsureCreated();
        }
    }
}
