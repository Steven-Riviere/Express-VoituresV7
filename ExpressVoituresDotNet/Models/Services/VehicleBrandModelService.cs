using ExpressVoituresDotNet.Models.Entities;
using ExpressVoituresDotNet.Models.Repositories;

namespace ExpressVoituresDotNet.Models.Services
{
    public class VehicleBrandModelService : IVehicleBrandModelService
    {
        private readonly IVehicleBrandModelRepository _repository;

        public VehicleBrandModelService(IVehicleBrandModelRepository repository)
        {
            _repository = repository;
        }

        public async Task AddBrandModelAsync(int brandId, int modelId)
        {
            if (await _repository.ExistsAsync(brandId, modelId))
                throw new InvalidOperationException("Cette association existe déjà.");

            await _repository.AddAsync(new VehicleBrandModel
            {
                VehicleBrandId = brandId,
                VehicleModelId = modelId
            });
        }

        public async Task RemoveBrandModelAsync(int brandId, int modelId)
        {
            await _repository.RemoveAsync(brandId, modelId);
        }

        public async Task<bool> ExistsAsync(int brandId, int modelId)
        {
            return await _repository.ExistsAsync(brandId, modelId);
        }
    }

}
