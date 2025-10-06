using ExpressVoituresDotNet.Models.Entities;

namespace ExpressVoituresDotNet.Models.Services
{
    public interface IVehicleBrandModelService
    {
        Task<IEnumerable<VehicleBrandModel>> GetAllVehicleBrandModelAsync();
        Task AddBrandModelAsync(int brandId, int modelId);
        Task RemoveBrandModelAsync(int brandId, int modelId);
        Task<bool> ExistsAsync(int brandId, int modelId);
    }

}
