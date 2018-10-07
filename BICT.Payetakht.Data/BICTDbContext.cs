﻿using System.Data.Entity;
using BICT.Payetakht.Data.Models;

namespace BICT.Payetakht.Data
{
    public class BICTDbContext : DbContext
    {
        public DbSet<CarManufacturer> CarManufacturers { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarYear> CarYears { get; set; }
        public DbSet<CarDetail> CarDetails { get; set; }
        public DbSet<City> Provinces { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarManufacturer>()
                        .HasMany(x => x.CarModels)
                        .WithRequired(x => x.CarManufacturer)
                        .HasForeignKey(x => x.CarManufacturerID)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarModel>()
                        .HasMany(x => x.CarYears)
                        .WithRequired(x => x.CarModel)
                        .HasForeignKey(x => x.CarModelID)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarYear>()
                      .HasMany(x => x.CarDetails)
                      .WithRequired(x => x.CarYear)
                      .HasForeignKey(x => x.CarYearID)
                      .WillCascadeOnDelete(false);

        }
    }
}
