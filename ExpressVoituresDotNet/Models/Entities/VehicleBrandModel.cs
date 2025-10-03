namespace ExpressVoituresDotNet.Models.Entities
{
    public class VehicleBrandModel
    {
        public int VehicleBrandId { get; set; }
        public int VehicleModelId { get; set; }

        public VehicleBrand VehicleBrand { get; set; } = null!;
        public VehicleModel VehicleModel { get; set; } = null!;
    }

}
