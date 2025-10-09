using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ExpressVoituresDotNet.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateApplicationDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "VehicleBrands",
                columns: new[] { "Id", "Brand" },
                values: new object[,]
                {
                    { 1, "Toyota" },
                    { 2, "Ford" },
                    { 3, "Honda" },
                    { 4, "Chevrolet" },
                    { 5, "Nissan" },
                    { 6, "Volkswagen" },
                    { 7, "Renault" },
                    { 8, "Peugeot" },
                    { 9, "Citroën" },
                    { 10, "Jeep" },
                    { 11, "Mazda" }
                });

            migrationBuilder.InsertData(
                table: "VehicleModels",
                columns: new[] { "Id", "Model" },
                values: new object[,]
                {
                    { 1, "Corolla" },
                    { 2, "Focus" },
                    { 3, "Civic" },
                    { 4, "Impala" },
                    { 5, "Altima" },
                    { 6, "Golf" },
                    { 7, "Clio" },
                    { 8, "208" },
                    { 9, "C3" },
                    { 10, "Wrangler" },
                    { 11, "CX-5" }
                });

            migrationBuilder.InsertData(
                table: "VehicleTrims",
                columns: new[] { "Id", "TrimLabel" },
                values: new object[,]
                {
                    { 1, "Base" },
                    { 2, "SE" },
                    { 3, "LE" },
                    { 4, "S" },
                    { 5, "SE" },
                    { 6, "Titanium" },
                    { 7, "LX" },
                    { 8, "EX" },
                    { 9, "Touring" }
                });

            migrationBuilder.InsertData(
                table: "VehicleBrandModels",
                columns: new[] { "VehicleBrandId", "VehicleModelId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 11 }
                });

            migrationBuilder.InsertData(
                table: "VehicleModelVehicleTrims",
                columns: new[] { "VehicleModelId", "VehicleTrimId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 },
                    { 3, 2 },
                    { 3, 4 },
                    { 4, 3 },
                    { 4, 5 },
                    { 5, 4 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Description", "Label", "MediaLabel", "MediaPath", "Purchase", "PurchasePrice", "Sale", "SalePrice", "Status", "VIN", "VehicleBrandId", "VehicleModelId", "VehicleTrimId", "YearOfProduction" },
                values: new object[,]
                {
                    { 1, "Vehicle description 1", "Vehicle 1", "CE.png", "/images/vehicles/CE.png", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15000m, null, null, 1, "1HGCM82633A123001", 1, 1, 1, 2020 },
                    { 2, "Vehicle description 2", "Vehicle 2", "CE.png", "/images/vehicles/CE.png", new DateTime(2021, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 18000m, null, null, 0, "1HGCM82633A123002", 2, 2, 1, 2021 },
                    { 3, "Vehicle description 3", "Vehicle 3", "CE.png", "/images/vehicles/CE.png", new DateTime(2019, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 16000m, new DateTime(2020, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 16500m, 2, "1HGCM82633A123003", 3, 3, 2, 2019 },
                    { 4, "Vehicle description 4", "Vehicle 4", "CE.png", "/images/vehicles/CE.png", new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 20000m, null, null, 1, "1HGCM82633A123004", 4, 4, 3, 2022 },
                    { 5, "Vehicle description 5", "Vehicle 5", "CE.png", "/images/vehicles/CE.png", new DateTime(2018, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 14000m, new DateTime(2019, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 14500m, 2, "1HGCM82633A123005", 5, 5, 4, 2018 },
                    { 6, "Vehicle description 6", "Vehicle 6", "CE.png", "/images/vehicles/CE.png", new DateTime(2021, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 22000m, null, null, 1, "1HGCM82633A123006", 6, 6, 5, 2021 },
                    { 7, "Vehicle description 7", "Vehicle 7", "CE.png", "/images/vehicles/CE.png", new DateTime(2020, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 13000m, null, null, 1, "1HGCM82633A123007", 7, 7, 6, 2020 },
                    { 8, "Vehicle description 8", "Vehicle 8", "CE.png", "/images/vehicles/CE.png", new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 15500m, new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 16000m, 2, "1HGCM82633A123008", 8, 8, 7, 2019 },
                    { 9, "Vehicle description 9", "Vehicle 9", "CE.png", "/images/vehicles/CE.png", new DateTime(2022, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 17500m, null, null, 0, "1HGCM82633A123009", 9, 9, 8, 2022 },
                    { 10, "Vehicle description 10", "Vehicle 10", "CE.png", "/images/vehicles/CE.png", new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 19000m, null, null, 1, "1HGCM82633A123010", 10, 10, 9, 2021 }
                });

            migrationBuilder.InsertData(
                table: "Repairs",
                columns: new[] { "Id", "Description", "RepairCost", "RepairDate", "VehicleId" },
                values: new object[,]
                {
                    { 1, "Repair description 1", 500.00m, new DateTime(2023, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "Repair description 2", 700.00m, new DateTime(2023, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, "Repair description 3", 600.00m, new DateTime(2023, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 4, "Repair description 4", 800.00m, new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 5, "Repair description 5", 900.00m, new DateTime(2023, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 6, "Repair description 6", 1000.00m, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 7, "Repair description 7", 1100.00m, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 8, "Repair description 8", 1200.00m, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Repairs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VehicleBrandModels",
                keyColumns: new[] { "VehicleBrandId", "VehicleModelId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "VehicleBrandModels",
                keyColumns: new[] { "VehicleBrandId", "VehicleModelId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "VehicleBrandModels",
                keyColumns: new[] { "VehicleBrandId", "VehicleModelId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "VehicleBrandModels",
                keyColumns: new[] { "VehicleBrandId", "VehicleModelId" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "VehicleBrandModels",
                keyColumns: new[] { "VehicleBrandId", "VehicleModelId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "VehicleBrandModels",
                keyColumns: new[] { "VehicleBrandId", "VehicleModelId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "VehicleBrandModels",
                keyColumns: new[] { "VehicleBrandId", "VehicleModelId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "VehicleBrandModels",
                keyColumns: new[] { "VehicleBrandId", "VehicleModelId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "VehicleBrandModels",
                keyColumns: new[] { "VehicleBrandId", "VehicleModelId" },
                keyValues: new object[] { 9, 9 });

            migrationBuilder.DeleteData(
                table: "VehicleBrandModels",
                keyColumns: new[] { "VehicleBrandId", "VehicleModelId" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "VehicleBrandModels",
                keyColumns: new[] { "VehicleBrandId", "VehicleModelId" },
                keyValues: new object[] { 11, 11 });

            migrationBuilder.DeleteData(
                table: "VehicleModelVehicleTrims",
                keyColumns: new[] { "VehicleModelId", "VehicleTrimId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "VehicleModelVehicleTrims",
                keyColumns: new[] { "VehicleModelId", "VehicleTrimId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "VehicleModelVehicleTrims",
                keyColumns: new[] { "VehicleModelId", "VehicleTrimId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "VehicleModelVehicleTrims",
                keyColumns: new[] { "VehicleModelId", "VehicleTrimId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "VehicleModelVehicleTrims",
                keyColumns: new[] { "VehicleModelId", "VehicleTrimId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "VehicleModelVehicleTrims",
                keyColumns: new[] { "VehicleModelId", "VehicleTrimId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "VehicleModelVehicleTrims",
                keyColumns: new[] { "VehicleModelId", "VehicleTrimId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "VehicleModelVehicleTrims",
                keyColumns: new[] { "VehicleModelId", "VehicleTrimId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "VehicleModelVehicleTrims",
                keyColumns: new[] { "VehicleModelId", "VehicleTrimId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "VehicleTrims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Vehicles",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VehicleBrands",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "VehicleModels",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "VehicleTrims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "VehicleTrims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "VehicleTrims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "VehicleTrims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "VehicleTrims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "VehicleTrims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "VehicleTrims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "VehicleTrims",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
