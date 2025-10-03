namespace ExpressVoituresDotNet.Models.Entities
{
    public class VehicleModelVehicleTrim
    {
        public int VehicleModelId { get; set; }
        public int VehicleTrimId { get; set; }

        public VehicleModel VehicleModel { get; set; } = null!;
        public VehicleTrim VehicleTrim { get; set; } = null!;
    }
}
