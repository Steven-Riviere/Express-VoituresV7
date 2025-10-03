namespace ExpressVoituresDotNet.Models.Entities
{
    public class VehicleBrand
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;

        public ICollection<VehicleBrandModel> VehicleBrandModels { get; set; } = new List<VehicleBrandModel>();
        public ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();

    }
}
