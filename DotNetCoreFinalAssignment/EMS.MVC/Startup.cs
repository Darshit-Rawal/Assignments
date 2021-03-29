using EMS.BE;
using EMS.BLL.Classes;
using EMS.BLL.Helper;
using EMS.BLL.Interfaces;
using EMS.DAL.Classes;
using EMS.DAL.Interfaces;
using EMS.MVC.Middlewares;
using EMS.MVC.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.MVC
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
            
            services.AddControllersWithViews();

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<EMSDbContext>();

            //services.AddDbContext<EMSDbContext>(
            //    options => options.UseSqlServer(Configuration.GetConnectionString("GetConnection"), b => b.MigrationsAssembly("EMS.MVC")));
            services.AddRazorPages();
            services.AddMvc();
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeManager, EmployeeManager>();
            services.AddTransient<IDepartmentManager, DepartmentManager>();

            ServiceHelper.Configure(services, Configuration.GetConnectionString("GetConnection"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/myapp-{Date}.txt");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseResponseCaching();

            app.Use(async (context, next) => {
                context.Response.GetTypedHeaders().CacheControl =
                new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
                {
                    Public = true,
                    MaxAge = TimeSpan.FromMilliseconds(500),
                    NoCache = true,
                };
                context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
                new string[] { "Accept-Encoding" };

                await next();
            });

            app.UseResponseTimeMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
