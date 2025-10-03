using ExpressVoituresDotNet.Models.Entities;
using ExpressVoituresDotNet.Models.Repositories;

namespace ExpressVoituresDotNet.Models.Services
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IVehicleBrandRepository _vehicleBrandRepository;

        public VehicleModelService(IVehicleModelRepository vehicleModelRepository, IVehicleBrandRepository vehicleBrandRepository)
        {
            _vehicleModelRepository = vehicleModelRepository;
            _vehicleBrandRepository = vehicleBrandRepository;
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
            var existingBrand = await _vehicleBrandRepository.GetVehicleBrandByIdAsync(brandId);
            if (existingBrand == null)
                throw new InvalidOperationException("La marque spécifiée est introuvable.");

            var existingModel = await _vehicleModelRepository.GetVehicleModelByNameAsync(modelName);
            if (existingModel != null)
                throw new InvalidOperationException("Ce modèle existe déjà.");

            var newModel = new VehicleModel
            {
                Model = modelName
            };

            newModel.VehicleBrandModels.Add(new Entities.VehicleBrandModel
            {
                VehicleBrandId = brandId,
                VehicleBrand = existingBrand,
                VehicleModel = newModel
            });

            await _vehicleModelRepository.AddVehicleModelAsync(newModel);

            return newModel;
        }

        public IEnumerable<VehicleBrand> GetBrandsOfModel(VehicleModel model)
        {
            return model.VehicleBrandModels.Select(vbm => vbm.VehicleBrand).ToList();
        }
    }
}
