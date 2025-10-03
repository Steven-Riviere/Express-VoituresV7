using ExpressVoituresDotNet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoituresDotNet.Data.SeedData
{
    public class VehicleModelData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleModel>().HasData(

            new VehicleModel { Id = 1, Model = "Corolla"},
            new VehicleModel { Id = 2, Model = "Focus" },
            new VehicleModel { Id = 3, Model = "Civic" },
            new VehicleModel { Id = 4, Model = "Impala" },
            new VehicleModel { Id = 5, Model = "Altima" },
            new VehicleModel { Id = 6, Model = "Golf" },
            new VehicleModel { Id = 7, Model = "Clio" },
            new VehicleModel { Id = 8, Model = "208" },
            new VehicleModel { Id = 9, Model = "C3" },
            new VehicleModel { Id = 10, Model = "Wrangler" },
            new VehicleModel { Id = 11, Model = "CX-5" }
            );
        }
    }
}
