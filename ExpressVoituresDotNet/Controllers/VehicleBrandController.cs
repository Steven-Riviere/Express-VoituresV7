using ExpressVoituresDotNet.Models.Entities;
using ExpressVoituresDotNet.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExpressVoituresDotNet.Controllers
{
    public class VehicleBrandController : Controller
    {
        private readonly IVehicleBrandService _vehicleBrandService;

        public VehicleBrandController(IVehicleBrandService vehicleBrandService)
        {
            _vehicleBrandService = vehicleBrandService;
        }

        public async Task<IActionResult> Index()
        {
            var brands = await _vehicleBrandService.GetAllVehicleBrandsAsync();
            return View(brands);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VehicleBrand vehicleBrand)
        {
            if (!ModelState.IsValid) return View(vehicleBrand);

            try
            {
                await _vehicleBrandService.AddNewBrandAsync(vehicleBrand.Brand);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(vehicleBrand);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _vehicleBrandService.GetVehicleBrandByIdAsync(id);
            if (brand == null) return NotFound();
            return View(brand);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehicleBrand brand)
        {
            if (id != brand.Id) return NotFound();
            if (!ModelState.IsValid) return View(brand);

            try
            {
                await _vehicleBrandService.UpdateBrandAsync(brand);
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(brand);
            }

        }
    }
}
