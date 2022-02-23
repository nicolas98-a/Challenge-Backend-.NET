using System.ComponentModel.DataAnnotations;

namespace Challenge.Backend.API.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }
    }
}
