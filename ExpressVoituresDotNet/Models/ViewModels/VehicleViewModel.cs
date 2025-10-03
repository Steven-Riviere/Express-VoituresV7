using ExpressVoituresDotNet.Models.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ExpressVoituresDotNet.Models.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Label { get; set; } = null!;

        [Required]
        public string VIN { get; set; } = null!;

        [MaxLength(250, ErrorMessage = "La description ne peut pas dépasser 250 caractères.")]
        public string? Description { get; set; }

        [Range(1990, 2025, ErrorMessage = "L'année de production doit être comprise entre 1990 et 2025.")]
        [Required]
        public int YearOfProduction { get; set; }

        [Required]
        public int VehicleBrandId { get; set; }

        [Required]
        public int VehicleModelId { get; set; }

        public int? VehicleTrimId { get; set; }

        public VehicleStatus Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Purchase { get; set; }

        [DataType(DataType.Currency)]
        public decimal? PurchasePrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Sale { get; set; }
        [DataType(DataType.Currency)]
        public decimal? SalePrice { get; set; }

        // Info média unique
        [BindNever]
        public string MediaLabel { get; set; } = null!;
        [BindNever]
        public string MediaPath { get; set; } = null!;
        [Required(ErrorMessage = "Une image est obligatoire.")]
        public IFormFile MediaFile { get; set; } = null!;

        // Infos liées (non bindées, juste pour affichage)
        [BindNever]
        public string? BrandName { get; set; }
        [BindNever]
        public string? ModelName { get; set; }
        [BindNever]
        public string? TrimName { get; set; }
       
        [MaxLength(250, ErrorMessage = "La description ne peut pas dépasser 250 caractères.")]
        public string? RepairDescription { get; set; }
       
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? RepairDate { get; set; }
       
        [DataType(DataType.Currency)]
        public decimal? RepairCost { get; set; }

        // Pour les dropdowns dans le formulaire
        [BindNever]
        public IEnumerable<SelectListItem>? VehicleBrands { get; set; }
        [BindNever]
        public IEnumerable<SelectListItem>? VehicleModels { get; set; }
        [BindNever]
        public IEnumerable<SelectListItem>? VehicleTrims { get; set; }
        [BindNever]
        public IEnumerable<SelectListItem>? YearsOfProduction { get; set; }
    }
}
