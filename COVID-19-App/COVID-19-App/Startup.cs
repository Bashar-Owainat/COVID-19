using COVID_19_App.covid19;
using COVID_19_App.Data;
using COVID_19_App.Models;
using COVID_19_App.Models.Interfaces;
using COVID_19_App.Models.Services;
using COVID_19_App.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19_App
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<COVID19DbContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });
           
            services.AddMvc(options => options.EnableEndpointRouting = false);
           


            services.AddSingleton<ITotalStatistics, TotalStatisticsServices>();
            services.AddSingleton<IGetTotalStatistics, GetTotalStatistics>();

            services.AddSingleton<ICountryStats, CountryStatsServices>();
            services.AddSingleton<IGetCountryStats, GetCountryStats>();

            services.AddTransient<ISummary, SummaryServices>();
            services.AddSingleton<IGetSummary, GetSummary>();

            services.AddSingleton<IGetSpecificSummary, GetSpecificSummary>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

             app.UseMvc();

            

        }
    }
}
