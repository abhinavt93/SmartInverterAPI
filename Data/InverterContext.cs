using System;
using Microsoft.EntityFrameworkCore;
using SmartInverterAPI.Models;

namespace SmartInverterAPI.Data
{
    public class InverterContext : DbContext
    {
        public DbSet<RawData> RawData { get; set; }

        public DbSet<LastHourData> LastHourData { get; set; }

        public DbSet<LastDayData> LastDayData { get; set; }

        public DbSet<LastMonthData> LastMonthData { get; set; }

        public DbSet<LastYearData> LastYearData { get; set; }

        public DbSet<LastDecadeData> LastDecadeData { get; set; }

        public DbSet<CurrentData> CurrentData { get; set; }

        public DbSet<DashboardData> DashboardData { get; set; }

        public DbSet<UserDataAndConfig> UserDataAndConfig { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Common;User Id=sa;Password=Password!23;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DashboardData>().ToTable("VW_DashboardData", t => t.ExcludeFromMigrations());

            modelBuilder
                .Entity<DashboardData>(
                    eb =>
                    {
                        eb.HasNoKey();
                        eb.ToView("VW_DashboardData");;
                    });

            modelBuilder.Entity<UserDataAndConfig>().HasData(
                new UserDataAndConfig
                    {
                        CustomerID = 610
                        , BatteryCapacitykWh = 1.8M
                        , NextGridCutOffTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 08, 00, 00)
                        , LoggedAt = DateTime.Now
                        , MinimumBatteryPerc = 10
                        , SolarPanelCapacityWatts = 330
                        , IsFirstRun = "Y"
                    }
                );

            modelBuilder.Entity<LastHourData>().HasData
                (
                    new LastHourData { Id = 1, Minute = 0 },
                    new LastHourData { Id = 2, Minute = 1 },
                    new LastHourData { Id = 3, Minute = 2 },
                    new LastHourData { Id = 4, Minute = 3 },
                    new LastHourData { Id = 5, Minute = 4 },
                    new LastHourData { Id = 6, Minute = 5 },
                    new LastHourData { Id = 7, Minute = 6 },
                    new LastHourData { Id = 8, Minute = 7 },
                    new LastHourData { Id = 9, Minute = 8 },
                    new LastHourData { Id = 10, Minute = 9 },
                    new LastHourData { Id = 11, Minute = 10 },
                    new LastHourData { Id = 12, Minute = 11 },
                    new LastHourData { Id = 13, Minute = 12 },
                    new LastHourData { Id = 14, Minute = 13 },
                    new LastHourData { Id = 15, Minute = 14 },
                    new LastHourData { Id = 16, Minute = 15 },
                    new LastHourData { Id = 17, Minute = 16 },
                    new LastHourData { Id = 18, Minute = 17 },
                    new LastHourData { Id = 19, Minute = 18 },
                    new LastHourData { Id = 20, Minute = 19 },
                    new LastHourData { Id = 21, Minute = 20 },
                    new LastHourData { Id = 22, Minute = 21 },
                    new LastHourData { Id = 23, Minute = 22 },
                    new LastHourData { Id = 24, Minute = 23 },
                    new LastHourData { Id = 25, Minute = 24 },
                    new LastHourData { Id = 26, Minute = 25 },
                    new LastHourData { Id = 27, Minute = 26 },
                    new LastHourData { Id = 28, Minute = 27 },
                    new LastHourData { Id = 29, Minute = 28 },
                    new LastHourData { Id = 30, Minute = 29 },
                    new LastHourData { Id = 31, Minute = 30 },
                    new LastHourData { Id = 32, Minute = 31 },
                    new LastHourData { Id = 33, Minute = 32 },
                    new LastHourData { Id = 34, Minute = 33 },
                    new LastHourData { Id = 35, Minute = 34 },
                    new LastHourData { Id = 36, Minute = 35 },
                    new LastHourData { Id = 37, Minute = 36 },
                    new LastHourData { Id = 38, Minute = 37 },
                    new LastHourData { Id = 39, Minute = 38 },
                    new LastHourData { Id = 40, Minute = 39 },
                    new LastHourData { Id = 41, Minute = 40 },
                    new LastHourData { Id = 42, Minute = 41 },
                    new LastHourData { Id = 43, Minute = 42 },
                    new LastHourData { Id = 44, Minute = 43 },
                    new LastHourData { Id = 45, Minute = 44 },
                    new LastHourData { Id = 46, Minute = 45 },
                    new LastHourData { Id = 47, Minute = 46 },
                    new LastHourData { Id = 48, Minute = 47 },
                    new LastHourData { Id = 49, Minute = 48 },
                    new LastHourData { Id = 50, Minute = 49 },
                    new LastHourData { Id = 51, Minute = 50 },
                    new LastHourData { Id = 52, Minute = 51 },
                    new LastHourData { Id = 53, Minute = 52 },
                    new LastHourData { Id = 54, Minute = 53 },
                    new LastHourData { Id = 55, Minute = 54 },
                    new LastHourData { Id = 56, Minute = 55 },
                    new LastHourData { Id = 57, Minute = 56 },
                    new LastHourData { Id = 58, Minute = 57 },
                    new LastHourData { Id = 59, Minute = 58 },
                    new LastHourData { Id = 60, Minute = 59 }

                );
        }
    }
}
