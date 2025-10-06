using ExpressVoituresDotNet.Models.Entities;

namespace ExpressVoituresDotNet.Models.Services
{
    public interface IVehicleModelVehicleTrimService
    {
        Task<IEnumerable<VehicleModelVehicleTrim>> GetAllVehicleModeTrimlAsync();
        Task<bool> ExistsAsync(int modelId, int trimId);
        Task AddAsync(int modelId, int trimId);
        Task RemoveAsync(int modelId, int trimId);
        Task<IEnumerable<VehicleModel>> GetModelsByTrimIdAsync(int trimId);
        Task<IEnumerable<VehicleTrim>> GetTrimsByModelIdAsync(int modelId);
    }
}
