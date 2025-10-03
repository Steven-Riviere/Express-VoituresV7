using ExpressVoituresDotNet.Models.Entities;

namespace ExpressVoituresDotNet.Models.Repositories
{
    public interface IVehicleBrandModelRepository
    {
        Task<bool> ExistsAsync(int brandId, int modelId);
        Task AddAsync(VehicleBrandModel entity);
        Task RemoveAsync(int brandId, int modelId);
        Task<IEnumerable<VehicleBrandModel>> GetAllAsync();
        Task<IEnumerable<VehicleModel>> GetModelsByBrandIdAsync(int brandId);
        Task<IEnumerable<VehicleBrand>> GetBrandsByModelIdAsync(int modelId);
    }
}
