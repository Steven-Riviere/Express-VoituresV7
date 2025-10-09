using ExpressVoituresDotNet.Data.SeedData;
using ExpressVoituresDotNet.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoituresDotNet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Repair> Repairs { get; set; } = null!;
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<VehicleBrand> VehicleBrands { get; set; } = null!;
        public DbSet<VehicleBrandModel> VehicleBrandModels { get; set; } = null!;
        public DbSet<VehicleModel> VehicleModels { get; set; } = null!;
        public DbSet<VehicleModelVehicleTrim> VehicleModelVehicleTrims { get; set; } = null!;
        public DbSet<VehicleTrim> VehicleTrims { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VehicleBrand>()
                .HasMany(b => b.Vehicles)
                .WithOne(v => v.VehicleBrand)
                .HasForeignKey(v => v.VehicleBrandId);

            modelBuilder.Entity<VehicleModel>()
                .HasMany(m => m.Vehicles)
                .WithOne(v => v.VehicleModel)
                .HasForeignKey(v => v.VehicleModelId);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Repair)
                .WithOne(r => r.Vehicle)
                .HasForeignKey<Repair>(r => r.VehicleId);

            modelBuilder.Entity<VehicleBrandModel>()
                .HasKey(bm => new { bm.VehicleBrandId, bm.VehicleModelId });

            modelBuilder.Entity<VehicleBrandModel>()
                .HasOne(bm => bm.VehicleBrand)
                .WithMany(b => b.VehicleBrandModels)
                .HasForeignKey(bm => bm.VehicleBrandId);

            modelBuilder.Entity<VehicleBrandModel>()
                .HasOne(bm => bm.VehicleModel)
                .WithMany(m => m.VehicleBrandModels)
                .HasForeignKey(bm => bm.VehicleModelId);

            modelBuilder.Entity<VehicleModelVehicleTrim>()
                .HasKey(mt => new { mt.VehicleModelId, mt.VehicleTrimId });

            modelBuilder.Entity<VehicleModelVehicleTrim>()
                .HasOne(mt => mt.VehicleModel)
                .WithMany(m => m.VehicleModelVehicleTrims)
                .HasForeignKey(mt => mt.VehicleModelId);

            modelBuilder.Entity<VehicleModelVehicleTrim>()
                .HasOne(mt => mt.VehicleTrim)
                .WithMany(t => t.VehicleModelVehicleTrims)
                .HasForeignKey(mt => mt.VehicleTrimId);

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.PurchasePrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Vehicle>()
                .Property(v => v.SalePrice)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Repair>()
                .Property(r => r.RepairCost)
                .HasColumnType("decimal(18,2)");

            RepairData.SeedData(modelBuilder);
            VehicleBrandData.SeedData(modelBuilder);
            VehicleBrandModelData.SeedData(modelBuilder);
            VehicleData.SeedData(modelBuilder);
            VehicleModelData.SeedData(modelBuilder);
            VehicleModelVehicleTrimData.SeedData(modelBuilder);
            VehicleTrimData.SeedData(modelBuilder);


        }
    }
}
