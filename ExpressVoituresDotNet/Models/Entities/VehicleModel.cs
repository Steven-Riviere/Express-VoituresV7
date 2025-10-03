namespace ExpressVoituresDotNet.Models.Entities
{
    public class VehicleModel
    {
        public int Id { get; set; }
        public string Model { get; set; } = null!;

        public ICollection<VehicleBrandModel> VehicleBrandModels { get; set; } = new List<VehicleBrandModel>();

        public ICollection<VehicleModelVehicleTrim> VehicleModelVehicleTrims { get; set; } = new List<VehicleModelVehicleTrim>();
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    }
}
