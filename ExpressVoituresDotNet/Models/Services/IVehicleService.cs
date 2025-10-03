using ExpressVoituresDotNet.Models.Entities;
using ExpressVoituresDotNet.Models.ViewModels;

namespace ExpressVoituresDotNet.Models.Services
{
    public interface IVehicleService
    {
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<Vehicle?> GetVehicleByIdAsync(int vehicleId);
        Task<Vehicle> AddVehicleAsync(VehicleViewModel vm);
        Task<IEnumerable<VehicleModel>> GetVehicleModelByBrandIdAsync(int brandId);
        Task UpdateVehicleAsync(VehicleViewModel vm);
        Task DeleteVehicleAsync(int vehicleId);
        Task<bool> VehicleExistsAsync(int vehicleId);
    }
}
