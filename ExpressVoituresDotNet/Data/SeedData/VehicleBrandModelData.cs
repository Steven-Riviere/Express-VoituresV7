using ExpressVoituresDotNet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoituresDotNet.Data.SeedData
{
    public class VehicleBrandModelData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleBrandModel>().HasData(
                new VehicleBrandModel { VehicleBrandId = 1, VehicleModelId = 1 },
                new VehicleBrandModel { VehicleBrandId = 2, VehicleModelId = 2 },
                new VehicleBrandModel { VehicleBrandId = 3, VehicleModelId = 3 },
                new VehicleBrandModel { VehicleBrandId = 4, VehicleModelId = 4 },
                new VehicleBrandModel { VehicleBrandId = 5, VehicleModelId = 5 },
                new VehicleBrandModel { VehicleBrandId = 6, VehicleModelId = 6 },
                new VehicleBrandModel { VehicleBrandId = 7, VehicleModelId = 7 },
                new VehicleBrandModel { VehicleBrandId = 8, VehicleModelId = 8 },
                new VehicleBrandModel { VehicleBrandId = 9, VehicleModelId = 9 },
                new VehicleBrandModel { VehicleBrandId = 10, VehicleModelId = 10 },
                new VehicleBrandModel { VehicleBrandId = 11, VehicleModelId = 11 }
            );
        }
    }
}
