using ExpressVoituresDotNet.Models.Entities;

namespace ExpressVoituresDotNet.Models.Repositories
{
    public interface IVehicleBrandRepository
    {
        Task<IEnumerable<VehicleBrand>> GetAllVehicleBrandsAsync();
        Task<VehicleBrand?> GetVehicleBrandByIdAsync(int vehicleBrandId);
        Task<VehicleBrand?> GetVehicleBrandWithModelsAsync(int vehicleBrandId);
        Task<VehicleBrand?> GetVehicleBrandByNameAsync(string brandName);
        Task AddVehicleBrandAsync(VehicleBrand vehicleBrand);
        Task UpdateVehicleBrandAsync(VehicleBrand vehicleBrand);

    }
}