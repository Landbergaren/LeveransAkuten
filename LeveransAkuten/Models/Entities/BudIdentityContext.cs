using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeveransAkuten.Models.Entities
{
    public class BudIdentityContext : IdentityDbContext<BudAkutenUsers>
    {
        public BudIdentityContext(DbContextOptions<BudIdentityContext> options) 
            : base(options)
        {
        }
    }
}
