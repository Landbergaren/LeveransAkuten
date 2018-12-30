using AutoMapper;
using LeveransAkuten.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.Services
{
    public class SearchDriverService
    {
        private readonly DbFirstContext appctx;
        private readonly IMapper mapper;
        
        private readonly RoleManager<IdentityRole> rolMan;
        private readonly UserManager<BudAkutenUsers> userMan;

        public SearchDriverService(DbFirstContext Appctx, IMapper mapper, RoleManager<IdentityRole> rolMan, UserManager<BudAkutenUsers> userMan)
        {
            appctx = Appctx;
            this.mapper = mapper;
         
            this.rolMan = rolMan;
            this.userMan = userMan;
        }
        
        public void Index1()
        {

            var x = userMan.GetUsersInRoleAsync("Driver").Result;

        }
    }
}
