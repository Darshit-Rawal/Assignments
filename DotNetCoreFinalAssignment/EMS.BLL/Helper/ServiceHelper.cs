using EMS.DAL.Classes;
using EMS.DAL.Context;
using EMS.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.BLL.Helper
{
    public class ServiceHelper
    {
        public static void Configure(IServiceCollection services, string ConnectionString)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<EMSDbContext>();

            services.AddDbContext<EMSDbContext>(
                options => options.UseSqlServer(ConnectionString, b => b.MigrationsAssembly("EMS.MVC")));

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        }
    }
}
