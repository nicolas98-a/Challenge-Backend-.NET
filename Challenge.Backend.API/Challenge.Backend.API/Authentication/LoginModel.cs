using System.ComponentModel.DataAnnotations;

namespace Challenge.Backend.API.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "El nombre de usuario es requerido")]
        public string Username { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        public string Password { get; set; }
    }
}
