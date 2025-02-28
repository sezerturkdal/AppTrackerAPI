using System;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace AppTrackerAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        public DbSet<Application> Applications { get; set; }
        public DbSet<Inquiry> Inquiries { get; set; }
        public DbSet<StatusLevel> StatusLevels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

          
        }
    }
}

