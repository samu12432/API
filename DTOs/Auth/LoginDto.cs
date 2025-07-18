using System.ComponentModel.DataAnnotations;

namespace API_REST_PROYECT.DTOs.Auth
{
    public class LoginDto
    {
        [Required (ErrorMessage = "Es necesario ingresar su nombre de usuario.")]
        public string userName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Es necesario ingresar su contraseña.")]
        public string password { get; set; } = string.Empty;
    }
}
