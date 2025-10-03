using System.ComponentModel.DataAnnotations;

namespace ExpressVoituresDotNet.Models.ViewModels
{
    public class LoginViewModel
    {

        [Required]
        [EmailAddress(ErrorMessage = "L'adresse e-mail n'est pas valide.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Le mot de passe est requis.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
