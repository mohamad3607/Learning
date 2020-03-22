using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mamedia.Src.Domain.Application.Interactors;
using Mamedia.Src.Domain.Application.Repositories;
using Mamedia.Src.Domain.Application.Services;
using Mamedia.Src.Infrastructure.Data;
using Mamedia.Src.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mamedia.Src.UI.Web
{
    public class Startup
    {
        private IConfiguration _conf { get; }
        private IHostingEnvironment _env { get; }
        public Startup(IHostingEnvironment env)
        {
            _env = env;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            _conf = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                //options.CheckConsentNeeded = context => true;
                //options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<MamediaDataContext>(
                opt => opt
                    .UseSqlServer(_conf.GetConnectionString("MamediaConnection")));

            services.AddScoped<IAdminService, AdminInteractor>();
            services.AddScoped<IAdminRepository, AdminRepository>();

            services.AddScoped<IAnonymouseService, AnonymouseInteractor>();
            services.AddScoped<IAnonymouseRepository, AnonymouseRepository>();

            services.AddScoped<IAccountService, AccountInteractor>();
            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<MamediaDataContext>();
                    //DBInitializer.SeedDB(ctx);
                }
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
