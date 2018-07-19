using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightsBooking.Models;
using FlightsBooking.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace FlightsBooking
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });
            var connectionString = Configuration["connectionString:flightDBConnectionString"];
            services.AddDbContext<FlightDBContext>(opts => opts.UseSqlServer(connectionString));
            services.AddMvc();
            services.AddScoped<IDatabaseRetrieval, DatabaseRetrieval>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, FlightDBContext flightDBContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            flightDBContext.SeedDataforDBContext();

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
