using CameraCounter.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CameraCounter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<ProductionOrder> ProductionOrders { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Issue> Issues { get; set; }
    }
}
