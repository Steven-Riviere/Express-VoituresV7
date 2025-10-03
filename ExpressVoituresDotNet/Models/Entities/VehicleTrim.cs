namespace ExpressVoituresDotNet.Models.Entities
{
    public class VehicleTrim
    {
        public int Id { get; set; }
        public string TrimLabel { get; set; } = null!;
        public ICollection<VehicleModelVehicleTrim> VehicleModelVehicleTrims { get; set; } = new List<VehicleModelVehicleTrim>();
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    }
}
