using ExpressVoituresDotNet.Models.Entities;
using ExpressVoituresDotNet.Models.ViewModels;

namespace ExpressVoituresDotNet.Models.Services
{
    public interface IRepairService
    {
        Task AddRepairAsync(Repair repair);
        Task<Repair?> GetRepairByVehicleIdAsync(int vehicleId);
        Task UpdateRepairAsync(int vehicleId, VehicleViewModel vehicleViewModel);
    }
}
