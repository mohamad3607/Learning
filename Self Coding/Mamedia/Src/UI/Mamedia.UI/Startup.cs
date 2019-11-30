using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mamedia.Domain.Application.Interactors;
using Mamedia.Domain.Application.Interfaces;
using Mamedia.Domain.Application.Services;
using Mamedia.Infrastructure.Data;
using Mamedia.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mamedia.UI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<MamediaDataContext>(
                    opt => opt
                        .UseSqlServer(_conf.GetConnectionString("MamediaConnection")));
            services.AddScoped<IPostService, PostInteractor>();
            services.AddScoped<IPostRepository, PostRepository>();

            services.AddScoped<ITrackService, TrackInteractor>();
            services.AddScoped<ITrackRepository, TrackRepository>();

            services.AddScoped<IArtistService, ArtistInteractor>();
            services.AddScoped<IArtistRepository, ArtistRepository>();

            services.AddScoped<IPurchasableAlbumService, PurchasableAlbumInteractor>();
            services.AddScoped<IPurchaseableAlbumRepository, PurchasableAlbumRepository>();
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

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
