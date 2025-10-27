using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressVoituresDotNet.Models.Entities;
using ExpressVoituresDotNet.Models.Services;
using ExpressVoituresDotNet.Models.ViewModels;
using Microsoft.CodeAnalysis.Differencing;

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

        public async Task<IActionResult> Create()
        {
            var vm = await PopulateViewModelSelectListsAsync(new VehicleViewModel());
            return View(vm);
        }

        public IActionResult CreateConfirmation()
        {
            return View();
        }


        public async Task<IActionResult> Details(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null) return NotFound();

            var vm = MapVehicleToViewModel(vehicle);
            return View(vm);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null) return NotFound();

            var vm = MapVehicleToViewModel(vehicle);
            await PopulateViewModelSelectListsAsync(vm);
            return View(vm);
        }

        public async Task<IActionResult> EditConfirmation(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null) return NotFound();

            var vm = MapVehicleToViewModel(vehicle);
            return View(vm);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var vehicle = await _vehicleService.GetVehicleByIdAsync(id);
            if (vehicle == null) return NotFound();

            var vm = MapVehicleToViewModel(vehicle);
            return View(vm);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleViewModel vm)
        {
            _logger.LogInformation("➡️ Début du POST Create véhicule");

            if (!await ValidateVehicleRelationsAsync(vm))
            {
                _logger.LogWarning("❌ Relations marque/modèle invalides");
                await PopulateViewModelSelectListsAsync(vm);
                return View(vm);
            }

            // Validation métier : au moins une image
            if (vm.MediaFile == null)
            {
                ModelState.AddModelError("MediaFile", "Une image est requise pour la création du véhicule.");
                _logger.LogWarning("❌ Aucune image n’a été fournie.");
            }

            if (!ModelState.IsValid)
            {
                _logger.LogWarning("❌ ModelState invalide : {errors}",
                string.Join(", ", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)));

                await PopulateViewModelSelectListsAsync(vm);
                return View(vm);
            }

            try
            {
                _logger.LogInformation("✅ Validation réussie — on tente d’ajouter le véhicule...");
                await _vehicleService.AddVehicleAsync(vm);
                _logger.LogInformation("✅ Véhicule ajouté avec succès !");
                return RedirectToAction(nameof(CreateConfirmation));
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

            if (!await ValidateVehicleRelationsAsync(vm))
            {
                await PopulateViewModelSelectListsAsync(vm);
                return View(vm);
            }

            if (!ModelState.IsValid)
            {
                await PopulateViewModelSelectListsAsync(vm);
                return View(vm);
            }

            try
            {
                await _vehicleService.UpdateVehicleAsync(vm);
                return RedirectToAction(nameof(EditConfirmation));
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

            var vm = vehicle != null ? MapVehicleToViewModel(vehicle) : null;
            return View("DeleteConfirmation", vm);
        }

        private async Task<bool> ValidateVehicleRelationsAsync(VehicleViewModel vm)
        {
            bool valid = true;

            if (!await _vehicleBrandModelService.ExistsAsync(vm.VehicleBrandId, vm.VehicleModelId))
            {
                ModelState.AddModelError("VehicleModelId", "Le modèle sélectionné n'appartient pas à la marque choisie.");
                valid = false;
            }

            if (vm.VehicleTrimId.HasValue &&
                !await _vehicleModelVehicleTrimService.ExistsAsync(vm.VehicleModelId, vm.VehicleTrimId.Value))
            {
                ModelState.AddModelError("VehicleTrimId", "La finition sélectionnée n'appartient pas au modèle choisi.");
                valid = false;
            }

            return valid;
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
                MediaPath = vehicle.MediaPath,

                BrandName = vehicle.VehicleBrand?.Brand,
                ModelName = vehicle.VehicleModel?.Model,
                TrimName = vehicle.VehicleTrim?.TrimLabel
            };
        }

        private async Task<VehicleViewModel> PopulateViewModelSelectListsAsync(VehicleViewModel viewModel)
        {
            viewModel.VehicleBrands = new SelectList(await _vehicleBrandService.GetAllVehicleBrandsAsync(), "Id", "Brand", viewModel.VehicleBrandId);
            viewModel.VehicleModels = new SelectList(await _vehicleModelService.GetAllVehicleModelsAsync(), "Id", "Model", viewModel.VehicleModelId);
            viewModel.VehicleTrims = new SelectList(await _vehicleTrimService.GetAllVehicleTrimsAsync(), "Id", "TrimLabel", viewModel.VehicleTrimId);

            var years = Enumerable.Range(1990, DateTime.Now.Year - 1990 + 1)
                                  .Select(y => new { Value = y, Text = y.ToString() });

            viewModel.YearsOfProduction = new SelectList(years, "Value", "Text", viewModel.YearOfProduction);
            return viewModel;
        }
    }
}
