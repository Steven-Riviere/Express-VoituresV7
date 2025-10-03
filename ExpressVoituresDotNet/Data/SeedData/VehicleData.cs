using ExpressVoituresDotNet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoituresDotNet.Data.SeedData
{
    public class VehicleData
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, Label = "Vehicle 1", VIN = "1HGCM82633A123001", Description = "Vehicle description 1", YearOfProduction = 2020, VehicleBrandId = 1, VehicleModelId = 1, VehicleTrimId = 1, Status = VehicleStatus.Disponible, Purchase = new DateTime(2020, 1, 1), PurchasePrice = 15000, SalePrice = null, MediaLabel = "CE.png", MediaPath = "/images/vehicles/CE.png" },
                new Vehicle { Id = 2, Label = "Vehicle 2", VIN = "1HGCM82633A123002", Description = "Vehicle description 2", YearOfProduction = 2021, VehicleBrandId = 2, VehicleModelId = 2, VehicleTrimId = 1, Status = VehicleStatus.Maintenance, Purchase = new DateTime(2021, 2, 15), PurchasePrice = 18000, SalePrice = null, MediaLabel = "CE.png", MediaPath = "/images/vehicles/CE.png" },
                new Vehicle { Id = 3, Label = "Vehicle 3", VIN = "1HGCM82633A123003", Description = "Vehicle description 3", YearOfProduction = 2019, VehicleBrandId = 3, VehicleModelId = 3, VehicleTrimId = 2, Status = VehicleStatus.Vendu, Purchase = new DateTime(2019, 5, 10), PurchasePrice = 16000, Sale = new DateTime(2020, 6, 12), SalePrice = 16500, MediaLabel = "CE.png", MediaPath = "/images/vehicles/CE.png" },
                new Vehicle { Id = 4, Label = "Vehicle 4", VIN = "1HGCM82633A123004", Description = "Vehicle description 4", YearOfProduction = 2022, VehicleBrandId = 4, VehicleModelId = 4, VehicleTrimId = 3, Status = VehicleStatus.Disponible, Purchase = new DateTime(2022, 3, 20), PurchasePrice = 20000, SalePrice = null, MediaLabel = "CE.png", MediaPath = "/images/vehicles/CE.png" },
                new Vehicle { Id = 5, Label = "Vehicle 5", VIN = "1HGCM82633A123005", Description = "Vehicle description 5", YearOfProduction = 2018, VehicleBrandId = 5, VehicleModelId = 5, VehicleTrimId = 4, Status = VehicleStatus.Vendu, Purchase = new DateTime(2018, 7, 1), PurchasePrice = 14000, Sale = new DateTime(2019, 8, 15), SalePrice = 14500, MediaLabel = "CE.png", MediaPath = "/images/vehicles/CE.png" },
                new Vehicle { Id = 6, Label = "Vehicle 6", VIN = "1HGCM82633A123006", Description = "Vehicle description 6", YearOfProduction = 2021, VehicleBrandId = 6, VehicleModelId = 6, VehicleTrimId = 5, Status = VehicleStatus.Disponible, Purchase = new DateTime(2021, 4, 12), PurchasePrice = 22000, SalePrice = null, MediaLabel = "CE.png", MediaPath = "/images/vehicles/CE.png" },
                new Vehicle { Id = 7, Label = "Vehicle 7", VIN = "1HGCM82633A123007", Description = "Vehicle description 7", YearOfProduction = 2020, VehicleBrandId = 7, VehicleModelId = 7, VehicleTrimId = 6, Status = VehicleStatus.Disponible, Purchase = new DateTime(2020, 9, 5), PurchasePrice = 13000, SalePrice = null, MediaLabel = "CE.png", MediaPath = "/images/vehicles/CE.png" },
                new Vehicle { Id = 8, Label = "Vehicle 8", VIN = "1HGCM82633A123008", Description = "Vehicle description 8", YearOfProduction = 2019, VehicleBrandId = 8, VehicleModelId = 8, VehicleTrimId = 7, Status = VehicleStatus.Vendu, Purchase = new DateTime(2019, 11, 18), PurchasePrice = 15500, Sale = new DateTime(2020, 12, 20), SalePrice = 16000, MediaLabel = "CE.png", MediaPath = "/images/vehicles/CE.png" },
                new Vehicle { Id = 9, Label = "Vehicle 9", VIN = "1HGCM82633A123009", Description = "Vehicle description 9", YearOfProduction = 2022, VehicleBrandId = 9, VehicleModelId = 9, VehicleTrimId = 8, Status = VehicleStatus.Maintenance, Purchase = new DateTime(2022, 1, 25), PurchasePrice = 17500, SalePrice = null, MediaLabel = "CE.png", MediaPath = "/images/vehicles/CE.png" },
                new Vehicle { Id = 10, Label = "Vehicle 10", VIN = "1HGCM82633A123010", Description = "Vehicle description 10", YearOfProduction = 2021, VehicleBrandId = 10, VehicleModelId = 10, VehicleTrimId = 9, Status = VehicleStatus.Disponible, Purchase = new DateTime(2021, 6, 30), PurchasePrice = 19000, SalePrice = null, MediaLabel = "CE.png", MediaPath = "/images/vehicles/CE.png" }
            );
        }
    }
}
