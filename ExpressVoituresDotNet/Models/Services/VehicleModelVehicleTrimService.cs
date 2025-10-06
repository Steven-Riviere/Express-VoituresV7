using ExpressVoituresDotNet.Models.Entities;
using ExpressVoituresDotNet.Models.Repositories;

namespace ExpressVoituresDotNet.Models.Services
{
    public class VehicleModelVehicleTrimService : IVehicleModelVehicleTrimService
    {
        private readonly IVehicleModelVehicleTrimRepository _vehicleModelVehicleTrimRepository;

        public VehicleModelVehicleTrimService(IVehicleModelVehicleTrimRepository repository)
        {
            _vehicleModelVehicleTrimRepository = repository;
        }

        public async Task<IEnumerable<VehicleModelVehicleTrim>> GetAllVehicleModeTrimlAsync()
        {
            return await _vehicleModelVehicleTrimRepository.GetAllVehicleModeTrimlAsync();
        }

        public async Task<bool> ExistsAsync(int modelId, int trimId)
        {
            return await _vehicleModelVehicleTrimRepository.ExistsAsync(modelId, trimId);
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
                await _vehicleModelVehicleTrimRepository.AddAsync(entity);
            }
        }

        public async Task RemoveAsync(int modelId, int trimId)
        {
            await _vehicleModelVehicleTrimRepository.RemoveAsync(modelId, trimId);
        }

        public async Task<IEnumerable<VehicleModel>> GetModelsByTrimIdAsync(int trimId)
        {
            return await _vehicleModelVehicleTrimRepository.GetModelsByTrimIdAsync(trimId);
        }

        public async Task<IEnumerable<VehicleTrim>> GetTrimsByModelIdAsync(int modelId)
        {
            return await _vehicleModelVehicleTrimRepository.GetTrimsByModelIdAsync(modelId);
        }
    }
}
