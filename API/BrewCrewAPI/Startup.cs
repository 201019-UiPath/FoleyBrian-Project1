using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using BrewCrewDB;
using BrewCrewDB.Models;
using BrewCrewDB.Repos;
using Microsoft.EntityFrameworkCore;
using BrewCrewLib;
using BrewCrewAPI.Controllers;

namespace BrewCrewAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<BrewCrewContext>(options => options.UseNpgsql(Configuration.GetConnectionString("BrewCrewDB")));
            services.AddScoped<IDataRepo<Brewery>, BreweryRepo>();
            services.AddScoped<IDataRepo<Beer>, BeerRepo>();
            services.AddScoped<IDataRepo<User>, UserRepo>();
            services.AddScoped<IDataRepo<LineItem>, LineItemRepo>();
            services.AddScoped<IDataRepo<BreweryManager>, BreweryManagerRepo>();
            services.AddScoped<IDataRepo<Order>, OrderRepo>();
            services.AddScoped<IService<Brewery>, Service<Brewery>>();
            services.AddScoped<IService<Beer>, Service<Beer>>();
            services.AddScoped<IService<User>, Service<User>>();
            services.AddScoped<IService<LineItem>, Service<LineItem>>();
            services.AddScoped<IService<BreweryManager>, Service<BreweryManager>>();
            services.AddScoped<IService<Order>, Service<Order>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
