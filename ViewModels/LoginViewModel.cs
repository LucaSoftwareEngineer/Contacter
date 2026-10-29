using System.ComponentModel.DataAnnotations;

namespace Contacter.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "L'email è obbligatoria.")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "La password è obbligatoria.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}