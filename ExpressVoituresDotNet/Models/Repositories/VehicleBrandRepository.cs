using ExpressVoituresDotNet.Data;
using ExpressVoituresDotNet.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpressVoituresDotNet.Models.Repositories
{
    public class VehicleBrandRepository : IVehicleBrandRepository
    {
        private readonly ApplicationDbContext _context;
        public VehicleBrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<VehicleBrand>> GetAllVehicleBrandsAsync()
        {
            return await _context.VehicleBrands.ToListAsync();
        }

        public async Task<VehicleBrand?> GetVehicleBrandByIdAsync(int vehicleBrandId)
        {
            return await _context.VehicleBrands.FirstOrDefaultAsync(c => c.Id == vehicleBrandId);
        }

        public async Task<VehicleBrand?> GetVehicleBrandWithModelsAsync(int vehicleBrandId)
        {
            return await _context.VehicleBrands
                .Include(vb => vb.VehicleBrandModels)   
                    .ThenInclude(vbm => vbm.VehicleModel) 
                .FirstOrDefaultAsync(vb => vb.Id == vehicleBrandId);
        }

        public async Task<VehicleBrand?> GetVehicleBrandByNameAsync(string brandName)
        {
            return await _context.VehicleBrands.FirstOrDefaultAsync(b => b.Brand == brandName);
        }

        public async Task AddVehicleBrandAsync(VehicleBrand vehicleBrand)
        {
            _context.VehicleBrands.Add(vehicleBrand);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateVehicleBrandAsync(VehicleBrand vehicleBrand)
        {
            _context.VehicleBrands.Update(vehicleBrand);
            await _context.SaveChangesAsync();
        }
    }
}
