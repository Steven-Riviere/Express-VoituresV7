using ExpressVoituresDotNet.Data;
using ExpressVoituresDotNet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoituresDotNet.Models.Repositories
{
    public class VehicleModelRepository : IVehicleModelRepository
    {
        private readonly ApplicationDbContext _context;
        public VehicleModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<VehicleModel>> GetAllVehicleModelsAsync()
        {
            return await _context.VehicleModels.ToListAsync();
        }

        public async Task<VehicleModel?> GetVehicleModelByIdAsync(int vehicleModelId)
        {
            return await _context.VehicleModels.FirstOrDefaultAsync(c => c.Id == vehicleModelId);
        }

        public async Task<VehicleModel?> GetVehicleModelByNameAsync(string modelName)
        {
            return await _context.VehicleModels.FirstOrDefaultAsync(m => m.Model == modelName);
        }

        public async Task AddVehicleModelAsync(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Add(vehicleModel);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateVehicleModelAsync(VehicleModel vehicleModel)
        {
            _context.VehicleModels.Update(vehicleModel);
            await _context.SaveChangesAsync();
        }
    }
}
