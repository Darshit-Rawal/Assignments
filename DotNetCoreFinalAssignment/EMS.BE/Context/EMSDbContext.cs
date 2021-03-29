using EMS.BE;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMS.DAL.Context
{
    public class EMSDbContext : IdentityDbContext
    {
        public EMSDbContext(DbContextOptions<EMSDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        { 
            base.OnModelCreating(builder);
        }

    }
}
