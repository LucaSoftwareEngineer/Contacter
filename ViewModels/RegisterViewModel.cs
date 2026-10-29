using System.ComponentModel.DataAnnotations;

namespace Contacter.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "L'email è obbligatoria.")]
        [EmailAddress(ErrorMessage = "Formato email non valido.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "La password è obbligatoria.")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "La password deve essere di almeno 6 caratteri.")]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Le password non coincidono.")]
        public string ConfirmPassword { get; set; } = null!;
    }
}