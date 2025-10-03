using ExpressVoituresDotNet.Models.Entities;

namespace ExpressVoituresDotNet.Models.Services
{
    public interface IVehicleModelService
    {
        Task<IEnumerable<VehicleModel>> GetAllVehicleModelsAsync();
        Task<VehicleModel?> GetVehicleModelByIdAsync(int modelId);
        Task<VehicleModel> AddNewModelAsync(string modelName, int brandId);
        IEnumerable<VehicleBrand> GetBrandsOfModel(VehicleModel model);
    }
}
