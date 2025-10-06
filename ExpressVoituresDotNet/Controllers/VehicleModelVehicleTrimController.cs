using ExpressVoituresDotNet.Models.Entities;
using System.Collections.Generic;
using ExpressVoituresDotNet.Models.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ExpressVoituresDotNet.Controllers
{
    public class VehicleModelVehicleTrimController : Controller
    {
        private readonly IVehicleModelVehicleTrimService _modelTrimService;
        private readonly IVehicleModelService _modelService;
        private readonly IVehicleTrimService _trimService;

        public VehicleModelVehicleTrimController(IVehicleModelVehicleTrimService modelTrimService,IVehicleModelService modelService,IVehicleTrimService trimService)
        {
            _modelTrimService = modelTrimService;
            _modelService = modelService;
            _trimService = trimService;
        }

        public async Task<IActionResult> Index()
        {
            var associations = await _modelTrimService.GetAllVehicleModeTrimlAsync();
            return View(associations);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Trims = await _trimService.GetAllVehicleTrimsAsync();
            ViewBag.Models = await _modelService.GetAllVehicleModelsAsync();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int modelId, int trimId)
        {
            if (await _modelTrimService.ExistsAsync(modelId, trimId))
            {
                ModelState.AddModelError("", "Cette association existe déjà.");
                ViewBag.Models = await _modelService.GetAllVehicleModelsAsync();
                ViewBag.Trims = await _trimService.GetAllVehicleTrimsAsync();
                return View();
            }

            await _modelTrimService.AddAsync(modelId, trimId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int modelId, int trimId)
        {
            await _modelTrimService.RemoveAsync(modelId, trimId);
            return RedirectToAction(nameof(Index));
        }

    }
}
