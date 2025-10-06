using ExpressVoituresDotNet.Data;
using ExpressVoituresDotNet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoituresDotNet.Models.Repositories
{
    public class VehicleModelVehicleTrimRepository : IVehicleModelVehicleTrimRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleModelVehicleTrimRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(int modelId, int trimId)
        {
            return await _context.VehicleModelVehicleTrims
                .AnyAsync(vbm => vbm.VehicleModelId == modelId && vbm.VehicleTrimId == trimId);
        }

        public async Task AddAsync(VehicleModelVehicleTrim entity)
        {
            _context.VehicleModelVehicleTrims.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int modelId, int trimId)
        {
            var entity = await _context.VehicleModelVehicleTrims
                .FirstOrDefaultAsync(vbm => vbm.VehicleModelId == modelId && vbm.VehicleTrimId == trimId);

            if (entity != null)
            {
                _context.VehicleModelVehicleTrims.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<VehicleModelVehicleTrim>> GetAllVehicleModeTrimlAsync()
        {
            return await _context.VehicleModelVehicleTrims
                .Include(vbm => vbm.VehicleModel)
                .Include(vbm => vbm.VehicleTrim)
                .ToListAsync();
        }

        public async Task<IEnumerable<VehicleModel>> GetModelsByTrimIdAsync(int trimId)
        {
            return await _context.VehicleModelVehicleTrims
                .Where(vbm => vbm.VehicleTrimId == trimId)
                .Include(vbm => vbm.VehicleModel)
                .Select(vbm => vbm.VehicleModel)
                .ToListAsync();
        }

        public async Task<IEnumerable<VehicleTrim>> GetTrimsByModelIdAsync(int modelId)
        {
            return await _context.VehicleModelVehicleTrims
                .Where(vbm => vbm.VehicleModelId == modelId)
                .Include(vbm => vbm.VehicleTrim)
                .Select(vbm => vbm.VehicleTrim)
                .ToListAsync();
        }
    }
}
