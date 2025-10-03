using ExpressVoituresDotNet.Models.Entities;

namespace ExpressVoituresDotNet.Models.Repositories
{
    public interface IVehicleTrimRepository
    {
        Task<IEnumerable<VehicleTrim>> GetAllVehicleTrimsAsync();
        Task<VehicleTrim> GetVehicleTrimByIdAsync(int VehicleTrimId);
        Task<VehicleTrim> GetVehicleTrimByNameAsync(string trimLabel);
        Task AddVehicleTrimAsync(VehicleTrim VehicleTrim);
        Task UpdateVehicleTrimAsync(VehicleTrim VehicleTrim);
    }
}
