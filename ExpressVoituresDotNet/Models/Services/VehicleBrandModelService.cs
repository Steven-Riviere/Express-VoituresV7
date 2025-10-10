using ExpressVoituresDotNet.Models.Entities;
using ExpressVoituresDotNet.Models.Repositories;

namespace ExpressVoituresDotNet.Models.Services
{
    public class VehicleBrandModelService : IVehicleBrandModelService
    {
        private readonly IVehicleBrandModelRepository _vehicleBrandModelRepository;

        public VehicleBrandModelService(IVehicleBrandModelRepository vehicleBrandModelRepository)
        {
            _vehicleBrandModelRepository = vehicleBrandModelRepository;
        }


        public async Task<IEnumerable<VehicleBrandModel>> GetAllVehicleBrandModelAsync()
        {
            return await _vehicleBrandModelRepository.GetAllVehicleBrandModelAsync();
        }


        public async Task AddBrandModelAsync(int brandId, int modelId)
        {
            if (await _vehicleBrandModelRepository.ExistsAsync(brandId, modelId))
                throw new InvalidOperationException("Cette association existe déjà.");

            await _vehicleBrandModelRepository.AddAsync(new VehicleBrandModel
            {
                VehicleBrandId = brandId,
                VehicleModelId = modelId
            });
        }

        public async Task RemoveBrandModelAsync(int brandId, int modelId)
        {
            await _vehicleBrandModelRepository.RemoveAsync(brandId, modelId);
        }

        public async Task<bool> ExistsAsync(int brandId, int modelId)
        {
            return await _vehicleBrandModelRepository.ExistsAsync(brandId, modelId);
        }

        public async Task<IEnumerable<VehicleModel>> GetModelsByBrandIdAsync(int brandId)
        {
            return await _vehicleBrandModelRepository.GetModelsByBrandIdAsync(brandId);
        }

    }

}
