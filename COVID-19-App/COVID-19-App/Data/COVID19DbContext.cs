using COVID_19_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COVID_19_App.Data
{
    public class COVID19DbContext : DbContext
    {
        public DbSet<TotalStatistic> TotalStatistics { get; set; }
        public DbSet<CountryData> Countries { get; set; }
        public DbSet<WholeSummary> Summaries { get; set; }
        public DbSet<Global> Global { get; set; }
        public DbSet<CountrySummary> CountrySummaries { get; set; }
        public DbSet<Premium> Premium { get; set; }






        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, but does nothing
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CountryData>().HasNoKey();
            modelBuilder.Entity<TotalStatistic>().HasNoKey();
            modelBuilder.Entity<Global>().HasNoKey();
         


        }
        public COVID19DbContext(DbContextOptions options): base(options)
        {

        }


    }
}
