namespace ExpressVoituresDotNet.Models.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Label { get; set; } = null!;
        public string VIN { get; set; } = null!;
        public string? Description { get; set; }
        public int YearOfProduction { get; set; }
        public VehicleStatus Status { get; set; }

        public DateTime Purchase {  get; set; }
        public decimal? PurchasePrice { get; set; }
        public DateTime? Sale { get; set; }
        public decimal? SalePrice { get; set; }

        public string MediaLabel { get; set; } = null!;
        public string MediaPath { get; set; } = null!;

        public int VehicleBrandId { get; set; }
        public VehicleBrand VehicleBrand { get; set; } = null!;
        public int VehicleModelId { get; set; }
        public VehicleModel VehicleModel { get; set; } = null!;
        public int? VehicleTrimId { get; set; }
        public VehicleTrim? VehicleTrim { get; set; }

        public Repair? Repair { get; set; }
    }

    public enum VehicleStatus
    {
        Maintenance = 0,
        Disponible = 1,
        Vendu = 2
    }
}
