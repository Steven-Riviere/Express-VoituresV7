using ExpressVoituresDotNet.Models.Entities;
using ExpressVoituresDotNet.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoituresDotNet.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IVehicleModelService _vehicleModelService;

        public VehicleModelController(IVehicleModelService vehicleModelService)
        {
            _vehicleModelService = vehicleModelService;
        }

        public async Task<IActionResult> Index()
        {
            var models = await _vehicleModelService.GetAllVehicleModelsAsync();
            return View(models);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleModel vehicleModel)
        {
            if (!ModelState.IsValid) return View(vehicleModel);

            try
            {
                await _vehicleModelService.AddNewModelAsync(vehicleModel.Model);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vehicleModel);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await _vehicleModelService.GetVehicleModelByIdAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehicleModel vehicleModel)
        {
            if (id != vehicleModel.Id) return NotFound();
            if (!ModelState.IsValid) return View(vehicleModel);

            try
            {
                await _vehicleModelService.UpdateModelAsync(vehicleModel);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vehicleModel);
            }

        }
    }
}
