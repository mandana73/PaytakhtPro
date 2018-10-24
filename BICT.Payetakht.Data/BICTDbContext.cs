namespace BICT.Payetakht.Data
{
    using System.Data.Entity;
    using BICT.Payetakht.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BICTDbContext : IdentityDbContext<ApplicationUser>
    {
        public BICTDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static BICTDbContext Create()
        {
            return new BICTDbContext();
        }

        public DbSet<CarManufacturer> CarManufacturers { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarYear> CarYears { get; set; }
        public DbSet<CarDetail> CarDetails { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<CarModelYearDetail> CarModelYearDetails { get; set; }
        public DbSet<Audit> Audit { get; set; }
        public DbSet<MetaKeyWord> MetaKeyWords { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole>()
                        .HasKey(r => new
                        {
                            r.UserId,
                            r.RoleId
                        }).ToTable("IdentityUserRole");

            modelBuilder.Entity<IdentityUserLogin>()
                        .HasKey(l => new
                        {
                            l.LoginProvider,
                            l.ProviderKey,
                            l.UserId
                        }).ToTable("IdentityUserLogin");

            modelBuilder.Entity<ApplicationUser>()
                        .ToTable("IdentityUser");

            modelBuilder.Entity<IdentityRole>()
                        .ToTable("IdentityRole");

            modelBuilder.Entity<IdentityUserClaim>()
                        .ToTable("IdentityUserClaim");

            modelBuilder.Entity<CarManufacturer>()
                        .HasMany(x => x.CarModels)
                        .WithRequired(x => x.CarManufacturer)
                        .HasForeignKey(x => x.CarManufacturerID)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarManufacturer>()
                  .HasMany(x => x.Audits)
                  .WithRequired(x => x.CarManufacturer)
                  .HasForeignKey(x => x.CarManufactureID)
                  .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarModel>()
                        .HasMany(x => x.CarYears)
                        .WithRequired(x => x.CarModel)
                        .HasForeignKey(x => x.CarModelID)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarModel>()
                      .HasMany(x => x.CarDetails)
                      .WithRequired(x => x.CarModel)
                      .HasForeignKey(x => x.CarModelID)
                      .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarModel>()
                .HasMany(x => x.CarModelYearDetails)
                .WithRequired(x => x.CarModel)
                .HasForeignKey(x => x.CarModelID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarModel>()
                .HasMany(x => x.Audits)
                .WithRequired(x => x.CarModel)
                .HasForeignKey(x => x.CarModelID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarDetail>()
                .HasMany(x => x.CarModelYearDetails)
                .WithRequired(x => x.CarDetail)
                .HasForeignKey(x => x.CarDetailID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarDetail>()
                .HasMany(x => x.Audits)
                .WithRequired(x => x.CarDetail)
                .HasForeignKey(x => x.CarDetailID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarYear>()
                .HasMany(x => x.CarModelYearDetails)
                .WithRequired(x => x.CarYear)
                .HasForeignKey(x => x.CarYearID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CarYear>()
                .HasMany(x => x.Audits)
                .WithRequired(x => x.CarYear)
                .HasForeignKey(x => x.CarYearID)
                .WillCascadeOnDelete(false);


        }
    }
}
