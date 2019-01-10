using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LeveransAkuten.Models;
using LeveransAkuten.Models.Entities;
using LeveransAkuten.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LeveransAkuten
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BudIdentityContext>(options =>
           {
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
           });
            services.AddDbContext<DbFirstContext>(options =>
           {
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
           });
            services.AddIdentity<BudAkutenUsers, IdentityRole>( options => {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<BudIdentityContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddTransient<RegistrationServices>();
            services.AddTransient<LoginServices>();
            services.AddTransient<AdsServices>();
            services.AddTransient<CompanyServices>();
            services.AddTransient<DriverService>();
           
            services.AddAutoMapper();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
