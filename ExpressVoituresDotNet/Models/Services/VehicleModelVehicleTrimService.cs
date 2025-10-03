using ExpressVoituresDotNet.Models.Entities;
using ExpressVoituresDotNet.Models.Repositories;

namespace ExpressVoituresDotNet.Models.Services
{
    public class VehicleModelVehicleTrimService : IVehicleModelVehicleTrimService
    {
        private readonly VehicleModelVehicleTrimRepository _repository;

        public VehicleModelVehicleTrimService(VehicleModelVehicleTrimRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> ExistsAsync(int modelId, int trimId)
        {
            return await _repository.ExistsAsync(modelId, trimId);
        }

        public async Task AddAsync(int modelId, int trimId)
        {
            if (!await ExistsAsync(modelId, trimId))
            {
                var entity = new VehicleModelVehicleTrim
                {
                    VehicleModelId = modelId,
                    VehicleTrimId = trimId
                };
                await _repository.AddAsync(entity);
            }
        }

        public async Task RemoveAsync(int modelId, int trimId)
        {
            await _repository.RemoveAsync(modelId, trimId);
        }

        public async Task<IEnumerable<VehicleModel>> GetModelsByTrimIdAsync(int trimId)
        {
            return await _repository.GetModelsByTrimIdAsync(trimId);
        }

        public async Task<IEnumerable<VehicleTrim>> GetTrimsByModelIdAsync(int modelId)
        {
            return await _repository.GetTrimsByModelIdAsync(modelId);
        }
    }
}
