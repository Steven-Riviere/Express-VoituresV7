using ExpressVoituresDotNet.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoituresDotNet.Controllers
{
    public class VehicleBrandVehicleModelController : Controller
    {
        private readonly IVehicleBrandModelService _brandModelService;
        private readonly IVehicleBrandService _brandService;
        private readonly IVehicleModelService _modelService;
    
    
        public VehicleBrandVehicleModelController(IVehicleBrandModelService brandModelService, IVehicleBrandService brandService, IVehicleModelService modelService)
        {
            _brandModelService = brandModelService;
            _brandService = brandService;
            _modelService = modelService;
        }

        [HttpGet]
        public async Task<IActionResult> GetModelsByBrand(int brandId)
        {
            var models = await _brandModelService.GetModelsByBrandIdAsync(brandId);
            return Json(models.Select(m => new { id = m.Id, name = m.Model }));
        }


        public async Task<IActionResult> Index()
        {
            var associations = await _brandModelService.GetAllVehicleBrandModelAsync();
            return View(associations);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Brands = await _brandService.GetAllVehicleBrandsAsync();
            ViewBag.Models = await _modelService.GetAllVehicleModelsAsync();
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int brandId, int modelId)
        {
            if (await _brandModelService.ExistsAsync(brandId, modelId))
            {
                ModelState.AddModelError("", "Cette association existe déjà.");
                ViewBag.Brands = await _brandService.GetAllVehicleBrandsAsync();
                ViewBag.Models = await _modelService.GetAllVehicleModelsAsync();
                return View();
            }

            await _brandModelService.AddBrandModelAsync(brandId, modelId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int brandId, int modelId)
        {
            await _brandModelService.RemoveBrandModelAsync(brandId, modelId);
            return RedirectToAction(nameof(Index));
        }
    }
}
