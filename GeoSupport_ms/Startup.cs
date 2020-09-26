using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoSupport_ms.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GeoSupport_ms
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
       
            string DB_P = Environment.GetEnvironmentVariable("DB_P");
            string DB_U = Environment.GetEnvironmentVariable("DB_U");
            string DB_S = Environment.GetEnvironmentVariable("DB_S");
            string DB_N = Environment.GetEnvironmentVariable("DB_N");
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(
                    "Data Source=" + DB_S + ";Database=" +
                    DB_N + ";User Id=" + DB_U + ";Password=" + DB_P + ";"));

            /*
             * use this when deployed to aws instance
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer(
                    "Data Source=" + DB_S + ";Database=" +
                    DB_N + ";User Id=" + DB_U + ";Password=" + DB_P + ";"));

            /*

            /*
             * use this when working in your own machine, put first ConnectionString in appsettings.json
             * to burn the DB values
            services.AddDbContext<AppDbContext>(
             options => options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"))
                );
             */

            services.AddControllers();
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
