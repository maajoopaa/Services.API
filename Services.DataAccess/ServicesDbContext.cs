using Microsoft.EntityFrameworkCore;
using Services.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess
{
    public class ServicesDbContext : DbContext
    {
        public ServicesDbContext(DbContextOptions<ServicesDbContext> options)
            : base(options) { }

        public DbSet<Specialization> Specializations { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Service> Services { get; set; }
    }
}
