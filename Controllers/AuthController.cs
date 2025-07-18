using API_REST_PROYECT.DTOs.Auth;
using API_REST_PROYECT.Exceptions.Register;
using API_REST_PROYECT.JWT;
using API_REST_PROYECT.Services;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace API_REST_PROYECT.Controllers
{
    [ApiController]
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("registerUser")]
        public async Task<IActionResult> RegisterUser(RegisterDto dto)
        {
            try
            {
                var result = await _authService.RegisterUser(dto);
                if (!result)
                    return Unauthorized("El correo ya está registrado."); //Codigo 401

                return Ok("Usuario registrado correctamente."); //Codigo 200
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(new { satus = 400, message = e.Message });
            }
            catch (EmailException e)
            {
                return BadRequest(new { satus = 400, message = e.Message });
            }
            catch (UserNameException e)
            {
                return BadRequest(new { satus = 400, message = e.Message });
            }

        }


        [HttpPost("loginuser")]
        public async Task<IActionResult> LoginUser(LoginDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState); //Codigo 400

                var token = await _authService.LoginUser(dto);

                if (token == null)
                    return Unauthorized("Credenciales incorretas"); //Codigo 401

                return Ok(new { token }); //Codigo 200
            }
            catch (Exception e)
            {
                return BadRequest(new
                {
                    satus = 500,
                    message = e.Message
                });
            }
        }
    }
}
