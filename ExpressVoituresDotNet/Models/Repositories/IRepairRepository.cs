using ExpressVoituresDotNet.Models.Entities;

namespace ExpressVoituresDotNet.Models.Repositories
{
    public interface IRepairRepository
    {
        Task<IEnumerable<Repair>> GetAllRepairsAsync();
        Task<Repair?> GetRepairByIdAsync(int id);
        Task<Repair?> GetRepairByVehicleIdAsync(int vehicleId);
        Task AddRepairAsync(Repair repair);
        Task UpdateRepairAsync(Repair repair);

    }
}
