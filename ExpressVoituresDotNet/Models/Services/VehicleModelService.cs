using ExpressVoituresDotNet.Models.Entities;
using ExpressVoituresDotNet.Models.Repositories;

namespace ExpressVoituresDotNet.Models.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleModelRepository _vehicleModelRepository;

        public VehicleModelService(IVehicleModelRepository vehicleModelRepository)
        {
            _vehicleModelRepository = vehicleModelRepository;
        }

        public async Task<IEnumerable<VehicleModel>> GetAllVehicleModelsAsync()
        {
            return await _vehicleModelRepository.GetAllVehicleModelsAsync();
        }

        public async Task<VehicleModel?> GetVehicleModelByIdAsync(int modelId)
        {
            return await _vehicleModelRepository.GetVehicleModelByIdAsync(modelId);
        }

        public async Task<VehicleModel> AddNewModelAsync(string modelName, int brandId)
        {
            var existingModel = await _vehicleModelRepository.GetVehicleModelByNameAsync(modelName);
            if (existingModel != null)
                throw new InvalidOperationException("Ce modèle existe déjà.");

            var newModel = new VehicleModel
            {
                Model = modelName
            };

            await _vehicleModelRepository.AddVehicleModelAsync(newModel);

            return newModel;
        }

        public async Task<VehicleModel?> UpdateModelAsync(VehicleModel model)
        {
            await _vehicleModelRepository.UpdateVehicleModelAsync(model);
            return model;
        }
    }
}
