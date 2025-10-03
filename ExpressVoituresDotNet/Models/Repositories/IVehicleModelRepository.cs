using ExpressVoituresDotNet.Models.Entities;

namespace ExpressVoituresDotNet.Models.Repositories
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<VehicleModel>> GetAllVehicleModelsAsync();
        Task<VehicleModel?> GetVehicleModelByIdAsync(int vehicleModelId);
        Task<VehicleModel?> GetVehicleModelByNameAsync(string modelName);
        Task<IEnumerable<VehicleModel>> GetVehicleModelsByBrandIdAsync(int brandId);
        Task AddVehicleModelAsync(VehicleModel vehicleModel);
        Task UpdateVehicleModelAsync(VehicleModel vehicleModel);
    }
}
