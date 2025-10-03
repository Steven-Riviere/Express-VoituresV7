using System.ComponentModel.DataAnnotations;

namespace ExpressVoituresDotNet.Models.Entities
{
    public class Repair
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string Description { get; set; } = null!;
        public DateTime RepairDate { get; set; }

        public decimal RepairCost { get; set; }

        public Vehicle Vehicle { get; set; } = null!;

    }
}
