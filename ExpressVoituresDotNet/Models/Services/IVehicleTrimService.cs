using ExpressVoituresDotNet.Models.Entities;

namespace ExpressVoituresDotNet.Models.Services
{
    public interface IVehicleTrimService
    {
        Task<IEnumerable<VehicleTrim>> GetAllVehicleTrimsAsync();
        Task<VehicleTrim> GetVehicleTrimByIdAsync(int trimId);
        Task<VehicleTrim> AddNewVehicleTrimAsync(string trimLabel);
    }
}
