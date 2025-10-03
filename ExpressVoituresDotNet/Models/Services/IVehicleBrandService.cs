using ExpressVoituresDotNet.Models.Entities;

namespace ExpressVoituresDotNet.Models.Services
{
    public interface IVehicleBrandService
    {
        Task<IEnumerable<VehicleBrand>> GetAllVehicleBrandsAsync();
        Task<VehicleBrand?> GetVehicleBrandByIdAsync(int brandId);
        Task<VehicleBrand?> AddNewBrandAsync(string brandName);
        Task<IEnumerable<VehicleModel>> GetModelsByBrandIdAsync(int brandId);

    }
}
