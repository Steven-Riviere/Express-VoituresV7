using ExpressVoituresDotNet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoituresDotNet.Data.SeedData
{
    public class VehicleModelVehicleTrimData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VehicleModelVehicleTrim>().HasData(

            new VehicleModelVehicleTrim { VehicleModelId = 1, VehicleTrimId = 1 },
            new VehicleModelVehicleTrim { VehicleModelId = 1, VehicleTrimId = 2 },
            new VehicleModelVehicleTrim { VehicleModelId = 2, VehicleTrimId = 1 },
            new VehicleModelVehicleTrim { VehicleModelId = 2, VehicleTrimId = 3 },
            new VehicleModelVehicleTrim { VehicleModelId = 3, VehicleTrimId = 2 },
            new VehicleModelVehicleTrim { VehicleModelId = 3, VehicleTrimId = 4 },
            new VehicleModelVehicleTrim { VehicleModelId = 4, VehicleTrimId = 3 },
            new VehicleModelVehicleTrim { VehicleModelId = 4, VehicleTrimId = 5 },
            new VehicleModelVehicleTrim { VehicleModelId = 5, VehicleTrimId = 4 }
            );
        }
    }
}
