using ExpressVoituresDotNet.Models.Entities;
using ExpressVoituresDotNet.Models.Repositories;
using ExpressVoituresDotNet.Models.ViewModels;

namespace ExpressVoituresDotNet.Models.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IVehicleModelRepository _vehicleModelRepository;
        private readonly IVehicleBrandRepository _vehicleBrandRepository;
        private readonly IVehicleBrandModelRepository _vehicleBrandModelRepository;

        public VehicleService(IVehicleRepository vehicleRepository, IVehicleModelRepository vehicleModelRepository, IVehicleBrandRepository vehicleBrandRepository, IVehicleBrandModelRepository vehicleBrandModelRepository)
        {
            _vehicleRepository = vehicleRepository;
            _vehicleModelRepository = vehicleModelRepository;
            _vehicleBrandRepository = vehicleBrandRepository;
            _vehicleBrandModelRepository = vehicleBrandModelRepository;
            _vehicleBrandModelRepository = vehicleBrandModelRepository;
        }

        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _vehicleRepository.GetAllVehiclesAsync();
        }

        public async Task<Vehicle?> GetVehicleByIdAsync(int vehicleId)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(vehicleId);
            if (vehicle != null && vehicle.Sale.HasValue && vehicle.Sale.Value < vehicle.Purchase)
                throw new InvalidOperationException("La date de vente ne peut pas être avant la date d'achat.");
            return vehicle;
        }

        public async Task<Vehicle> AddVehicleAsync(VehicleViewModel vm)
        {

            if (vm.MediaFile == null)
                throw new InvalidOperationException("Une image est obligatoire.");

            var uniqueFileName = $"{Guid.NewGuid()}_{vm.MediaFile.FileName}";
            var mediaPath = Path.Combine("wwwroot/images/vehicles", uniqueFileName);
            using var stream = new FileStream(mediaPath, FileMode.Create);
            await vm.MediaFile.CopyToAsync(stream);

            var exists = await _vehicleBrandModelRepository.ExistsAsync(vm.VehicleBrandId, vm.VehicleModelId);
            if (!exists)
                throw new InvalidOperationException($"Le modèle {vm.VehicleModelId} n'appartient pas à la marque {vm.VehicleBrandId}.");

            Vehicle vehicle = new Vehicle
            {
                Label = vm.Label,
                VIN = vm.VIN,
                Description = vm.Description,
                YearOfProduction = vm.YearOfProduction,
                VehicleBrandId = vm.VehicleBrandId,
                VehicleModelId = vm.VehicleModelId,
                VehicleTrimId = vm.VehicleTrimId,
                Status = VehicleStatus.Disponible,
                Purchase = vm.Purchase,
                PurchasePrice = vm.PurchasePrice,
                MediaLabel = vm.MediaFile.FileName,
                MediaPath = "/images/vehicles/" + uniqueFileName
            };

            await _vehicleRepository.AddVehicleAsync(vehicle);
            return vehicle;
        }

        public async Task<IEnumerable<VehicleModel>> GetVehicleModelByBrandIdAsync(int brandId)
        {
            return await _vehicleBrandModelRepository.GetModelsByBrandIdAsync(brandId);
        }


        public async Task UpdateVehicleAsync(VehicleViewModel vm)
        {
            var vehicle = await _vehicleRepository.GetVehicleByIdAsync(vm.Id);
            if (vehicle == null) 
                throw new InvalidOperationException("Véhicule introuvable");

            vehicle.Label = vm.Label;
            vehicle.VIN = vm.VIN;
            vehicle.Description = vm.Description;
            vehicle.YearOfProduction = vm.YearOfProduction;
            vehicle.VehicleBrandId = vm.VehicleBrandId;
            vehicle.VehicleModelId = vm.VehicleModelId;
            vehicle.VehicleTrimId = vm.VehicleTrimId;
            vehicle.Purchase = vm.Purchase;
            vehicle.PurchasePrice = vm.PurchasePrice;

            if (vm.RepairDate.HasValue || vm.RepairCost.HasValue || !string.IsNullOrEmpty(vm.RepairDescription))
            {
                if (vehicle.Repair == null) vehicle.Repair = new Repair { VehicleId = vehicle.Id };

                if (vm.RepairDate.HasValue)
                    vehicle.Repair.RepairDate = vm.RepairDate.Value;

                if (vm.RepairCost.HasValue)
                    vehicle.Repair.RepairCost = vm.RepairCost.Value;

                if (!string.IsNullOrEmpty(vm.RepairDescription))
                    vehicle.Repair.Description = vm.RepairDescription;
            }

            var exists = await _vehicleBrandModelRepository.ExistsAsync(vm.VehicleBrandId, vm.VehicleModelId);
            if (!exists)
                throw new InvalidOperationException($"Le modèle {vm.VehicleModelId} n'appartient pas à la marque {vm.VehicleBrandId}.");


            if (vm.SalePrice.HasValue)
            {
                vehicle.SalePrice = vm.SalePrice;
                vehicle.Sale = vm.Sale;

                if (vm.Sale.HasValue)
                    vehicle.Status = VehicleStatus.Vendu;
                else
                    vehicle.Status = VehicleStatus.Disponible;
            }

            if (vm.MediaFile != null)
            {
                var uniqueFileName = $"{Guid.NewGuid()}_{vm.MediaFile.FileName}";
                var mediaPath = Path.Combine("wwwroot/images/vehicles", uniqueFileName);
                using var stream = new FileStream(mediaPath, FileMode.Create);
                await vm.MediaFile.CopyToAsync(stream);

                vehicle.MediaPath = "/images/vehicles/" + uniqueFileName;
                vehicle.MediaLabel = vm.MediaFile.FileName;
            }

            await _vehicleRepository.UpdateVehicleAsync(vehicle);
        }

        public async Task DeleteVehicleAsync(int vehicleId)
        {
            await _vehicleRepository.DeleteVehicleAsync(vehicleId);
        }

        public async Task<bool> VehicleExistsAsync(int vehicleId)
        {
            return await _vehicleRepository.VehicleExistsAsync(vehicleId);
        }

        public async Task<bool> ValidateVehicleModelWithBrandAsync(int modelId, int brandId)
        {
            return await _vehicleRepository.ValidateVehicleModelWithBrandAsync(modelId, brandId);
        }

    }
}
