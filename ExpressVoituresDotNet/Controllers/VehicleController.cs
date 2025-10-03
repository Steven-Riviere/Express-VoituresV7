using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressVoituresDotNet.Models.Entities;
using ExpressVoituresDotNet.Models.Services;
using ExpressVoituresDotNet.Models.ViewModels;

namespace ExpressVoituresDotNet.Controllers
{
    public class VehicleController : Controller
    {

        private readonly ILogger<VehicleController> _logger;
        private readonly IVehicleService _vehicleService;
        private readonly IVehicleBrandService _vehicleBrandService;
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IVehicleTrimService _vehicleTrimService;
        private readonly IVehicleBrandModelService _vehicleBrandModelService;
        private readonly IVehicleModelVehicleTrimService _vehicleModelVehicleTrimService;

        public VehicleController(ILogger<VehicleController> logger, IVehicleService vehicleService, IVehicleBrandService vehicleBrandService, IVehicleModelService vehicleModelService, IVehicleTrimService vehicleTrimService,IVehicleBrandModelService vehicleBrandModelService,IVehicleModelVehicleTrimService vehicleModelVehicleTrimService)
        {
            _logger = logger;
            _vehicleService = vehicleService;
            _vehicleBrandService = vehicleBrandService;
            _vehicleTrimService = vehicleTrimService;
            _vehicleModelService = vehicleModelService;
            _vehicleBrandModelService = vehicleBrandModelService;
            _vehicleModelVehicleTrimService = vehicleModelVehicleTrimService;
        }

        public async Task<IActionResult> Index()
        {
            var vehicle = await _vehicleService.GetAllVehiclesAsync();
            return View(vehicle);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var vm = new VehicleViewModel();
            await PopulateViewModelSelectListsAsync(vm);
            return View(vm);
        }

        public async Task<IActionResult> Details(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null) return NotFound();
            return View(vehicle);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null) return NotFound();

            var vm = MapVehicleToViewModel(vehicle);
            await PopulateViewModelSelectListsAsync(vm);
            return View(vm);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null) return NotFound();
            return View(vehicle);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleViewModel vm)
        {
            // Validation métier : modèle appartient à la marque
            if (!await _vehicleBrandModelService.ExistsAsync(vm.VehicleBrandId, vm.VehicleModelId))
            {
                ModelState.AddModelError("VehicleModelId", "Le modèle sélectionné n'appartient pas à la marque choisie.");
            }
            // Validation métier : marque appartient à la finition
            if (vm.VehicleTrimId.HasValue && !await _vehicleModelVehicleTrimService.ExistsAsync(vm.VehicleModelId, vm.VehicleTrimId.Value))
            {
                ModelState.AddModelError("VehicleTrimId", "La finition sélectionnée n'appartient pas au modèle choisi.");
            }

            if (!ModelState.IsValid || vm.MediaFile == null)
            {
                if (vm.MediaFile == null)
                    ModelState.AddModelError("MediaFile", "Une image est obligatoire.");

                LogModelStateErrors();
                await PopulateViewModelSelectListsAsync(vm);
                return View(vm);
            }

            try
            {
                await _vehicleService.AddVehicleAsync(vm);
                return View("CreateConfirmation", vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur création véhicule");
                ModelState.AddModelError("", "Impossible de créer le véhicule.");
                await PopulateViewModelSelectListsAsync(vm);
                return View(vm);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehicleViewModel vm)
        {
            if (id != vm.Id)
                return NotFound();

            if (!await _vehicleBrandModelService.ExistsAsync(vm.VehicleBrandId, vm.VehicleModelId))
            {
                ModelState.AddModelError("VehicleModelId", "Le modèle sélectionné n'appartient pas à la marque choisie.");
            }

            if (vm.VehicleTrimId.HasValue && !await _vehicleModelVehicleTrimService.ExistsAsync(vm.VehicleModelId, vm.VehicleTrimId.Value))
            {
                ModelState.AddModelError("VehicleTrimId", "La finition sélectionnée n'appartient pas au modèle choisi.");
            }

            if (!ModelState.IsValid)
            {
                LogModelStateErrors();
                await PopulateViewModelSelectListsAsync(vm);
                return View(vm);
            }

            try
            {
                await _vehicleService.UpdateVehicleAsync(vm);
                return View("EditConfirmation", vm);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erreur édition véhicule");
                ModelState.AddModelError("", "Impossible de mettre à jour le véhicule.");
                await PopulateViewModelSelectListsAsync(vm);
                return View(vm);
            }
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle != null)
                await _vehicleService.DeleteVehicleAsync(id);

            return View("DeleteConfirmation", vehicle);
        }

        private void LogModelStateErrors()
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                _logger.LogError(error.ErrorMessage);
        }

        private VehicleViewModel MapVehicleToViewModel(Vehicle vehicle)
        {
            return new VehicleViewModel
            {
                Id = vehicle.Id,
                Label = vehicle.Label,
                VIN = vehicle.VIN,
                Description = vehicle.Description,
                YearOfProduction = vehicle.YearOfProduction,
                VehicleBrandId = vehicle.VehicleBrandId,
                VehicleModelId = vehicle.VehicleModelId,
                VehicleTrimId = vehicle.VehicleTrimId,
                Status = vehicle.Status,
                Purchase = vehicle.Purchase,
                PurchasePrice = vehicle.PurchasePrice,
                Sale = vehicle.Sale,
                SalePrice = vehicle.SalePrice,
                RepairDate = vehicle.Repair?.RepairDate,
                RepairCost = vehicle.Repair?.RepairCost,
                RepairDescription = vehicle.Repair?.Description,
                MediaLabel = vehicle.MediaLabel,
                MediaPath = vehicle.MediaPath
            };
        }

        private async Task<VehicleViewModel> PopulateViewModelSelectListsAsync(VehicleViewModel? viewModel = null)
        {
            viewModel ??= new VehicleViewModel();

            var brands = await _vehicleBrandService.GetAllVehicleBrandsAsync();
            var models = await _vehicleModelService.GetAllVehicleModelsAsync();
            var trims = await _vehicleTrimService.GetAllVehicleTrimsAsync();

            viewModel.VehicleBrands = new SelectList(brands, "Id", "Brand", viewModel.VehicleBrandId);
            viewModel.VehicleModels = new SelectList(models, "Id", "Model", viewModel.VehicleModelId);
            viewModel.VehicleTrims = new SelectList(trims, "Id", "TrimLabel", viewModel.VehicleTrimId);

            return viewModel;
        }
    }
}
