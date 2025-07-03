using Microsoft.EntityFrameworkCore;
using Mvc.Domain.Entities;
using System.Collections.Generic;

namespace Mvc.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Staff> Staffs { get; set; }
    }
}
