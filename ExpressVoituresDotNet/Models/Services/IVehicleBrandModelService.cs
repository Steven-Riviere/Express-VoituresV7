namespace ExpressVoituresDotNet.Models.Services
{
    public interface IVehicleBrandModelService
    {
        Task AddBrandModelAsync(int brandId, int modelId);
        Task RemoveBrandModelAsync(int brandId, int modelId);
        Task<bool> ExistsAsync(int brandId, int modelId);
    }

}
