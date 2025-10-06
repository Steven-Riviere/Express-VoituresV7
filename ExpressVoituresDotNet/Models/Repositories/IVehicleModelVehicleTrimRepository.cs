using ExpressVoituresDotNet.Models.Entities;

namespace ExpressVoituresDotNet.Models.Repositories
{
    public interface IVehicleModelVehicleTrimRepository
    {
        Task<bool> ExistsAsync(int modelId, int trimId);
        Task AddAsync(VehicleModelVehicleTrim entity);
        Task RemoveAsync(int modelId, int trimId);
        Task<IEnumerable<VehicleModelVehicleTrim>> GetAllVehicleModeTrimlAsync();
        Task<IEnumerable<VehicleModel>> GetModelsByTrimIdAsync(int trimId);
        Task<IEnumerable<VehicleTrim>> GetTrimsByModelIdAsync(int modelId);
    }
}
