using AutoMapper;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.ViewModels.SearchDriver;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace LeveransAkuten.Models.Services
{
    public class SearchDriverServices
    {
        private readonly DbFirstContext appctx;
        private readonly IMapper mapper;

        private readonly RoleManager<IdentityRole> rolMan;
        private readonly UserManager<BudAkutenUsers> userMan;

        public SearchDriverServices(DbFirstContext Appctx, IMapper mapper, RoleManager<IdentityRole> rolMan, UserManager<BudAkutenUsers> userMan)
        {
            appctx = Appctx;
            this.mapper = mapper;

            this.rolMan = rolMan;
            this.userMan = userMan;
        }

        public List<List<SearchDriverVm>> GetDriverList()
        {

            var DriverLists = new List<List<SearchDriverVm>>();
            var Drivers = userMan.GetUsersInRoleAsync("Driver").Result.Select(x => x).ToList();
            foreach (var item in Drivers)
            {

                var DriverList = userMan.GetClaimsAsync(item).Result.Select(d => new SearchDriverVm { Value = d.Value, Email = item.Email }).ToList();
                DriverLists.Add(DriverList);
            }

            return DriverLists;

        }


    }
}
