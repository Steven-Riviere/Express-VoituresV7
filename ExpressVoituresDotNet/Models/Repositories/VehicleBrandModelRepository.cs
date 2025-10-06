using ExpressVoituresDotNet.Data;
using ExpressVoituresDotNet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoituresDotNet.Models.Repositories
{
    public class VehicleBrandModelRepository : IVehicleBrandModelRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleBrandModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExistsAsync(int brandId, int modelId)
        {
            return await _context.VehicleBrandModels
                .AnyAsync(vbm => vbm.VehicleBrandId == brandId && vbm.VehicleModelId == modelId);
        }

        public async Task AddAsync(VehicleBrandModel entity)
        {
            _context.VehicleBrandModels.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(int brandId, int modelId)
        {
            var entity = await _context.VehicleBrandModels
                .FindAsync(brandId, modelId);

            if (entity != null)
            {
                _context.VehicleBrandModels.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<VehicleBrandModel>> GetAllVehicleBrandModelAsync()
        {
            return await _context.VehicleBrandModels
                .Include(vbm => vbm.VehicleBrand)
                .Include(vbm => vbm.VehicleModel)
                .ToListAsync();
        }

        public async Task<IEnumerable<VehicleModel>> GetModelsByBrandIdAsync(int brandId)
        {
            return await _context.VehicleBrandModels
                .Where(vbm => vbm.VehicleBrandId == brandId)
                .Include(vbm => vbm.VehicleModel)
                .Select(vbm => vbm.VehicleModel)
                .ToListAsync();
        }

        public async Task<IEnumerable<VehicleBrand>> GetBrandsByModelIdAsync(int modelId)
        {
            return await _context.VehicleBrandModels
                .Where(vbm => vbm.VehicleModelId == modelId)
                .Include(vbm => vbm.VehicleBrand)
                .Select(vbm => vbm.VehicleBrand)
                .ToListAsync();
        }
    }
}
