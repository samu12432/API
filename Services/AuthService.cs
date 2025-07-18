using System.Security.Cryptography;
using System.Text;
using API_REST_PROYECT.Data;
using API_REST_PROYECT.DTOs.Auth;
using API_REST_PROYECT.Exceptions.Register;
using API_REST_PROYECT.IRepository;
using API_REST_PROYECT.IServices;
using API_REST_PROYECT.JWT;
using Users = API_REST_PROYECT.Models.User;
using API_REST_PROYECT.Models;
using Microsoft.Extensions.Options;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API_REST_PROYECT.Services
{
    public class AuthService : IAuthService
    {
        private readonly ContextDb _contextDbAplication;
        private readonly Token _optionToken;
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailSender;
        private readonly JwtSettingsConfirmation _jwt;

        public AuthService(ContextDb contextDb, Token token, IUserRepository repo, IEmailService emailSender, IOptions<JwtSettingsConfirmation> jwtOptions)
        {
            _contextDbAplication = contextDb;
            _optionToken = token;
            _userRepository = repo;
            _emailSender = emailSender;
            _jwt = jwtOptions.Value;
        }

        public async Task<string?> LoginUser(LoginDto dto)
        {
            //Validamos que el dto no sea vacio
            if (dto == null) throw new Exception("Datos incorrectos.");

            //Obtenemos el usuario
            var user = await _userRepository.GetUserByInfo(dto.userName);

            //Validamos que no exista un usuario y verificamos password (a traves del hash y salt, DEBEN SER LAS MISMAS)
            if (user == null || !VerificarPassword(dto.password, user.passwordHash, user.passwordSalt)) throw new Exception("Lo sentimos, credenciales incorrectas.");

            //Generamos un token y devolvemos para iniciar la sesion
            var t = _optionToken.GenerateToken(user);
            return t;
        }

        public async Task<bool> RegisterUser(RegisterDto dto)
        {

            //Validamos que el dto no sea vacio
            if (dto == null) throw new Exception("Datos incorrectos.");

            //Validamos que no exista el usuario
            var exist = await _userRepository.GetByEmailAsync(dto.userEmail);
            if (exist != null)
                throw new EmailException("Ya existe un usuario creado con ese correo.");

            exist = await _userRepository.GetUserByInfo(dto.userName);
            if (exist != null)
                throw new UserNameException("Ya existe un usuario creado con ese nombre de usuario.");

            //Generamos un Hash con la contraseña
            CrearHashySalt(dto.password, out byte[] salt, out byte[] hash);

            //Generamos un usuario
            Users newUser = new Users(dto.name, dto.userEmail, dto.phoneNumber, dto.userName, hash, salt);

            //Accedemos a la Db y guardamos
            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();

            var token = GenerateEmailToken(newUser.userEmail);
            var link = $"https://localhost:5001/api/auth/confirm-email?token={token}";
            var body = $"Hola {newUser.userName}, haz clic aquí para confirmar tu correo: <a href='{link}'>Confirmar</a>";

            await _emailSender.SendAsync(newUser.userEmail, "Confirmación de correo", body);
            return true;
        }

        private void CrearHashySalt(string password, out byte[] salt, out byte[] hash)
        {
            using var hmac = new HMACSHA512();
            salt = hmac.Key;
            hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }

        private bool VerificarPassword(string password, byte[] hash, byte[] salt)
        {
            using var hmac = new HMACSHA512(salt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return hash.SequenceEqual(computedHash);
        }

        public async Task<bool> ConfirmEmailAsync(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));

                var principal = handler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = _jwt.Issuer,
                    ValidAudience = _jwt.Audience,
                    IssuerSigningKey = key,
                    ValidateLifetime = true
                }, out _);

                var email = principal.FindFirst(ClaimTypes.Email)?.Value;
                if (email == null) return false;

                var user = await _userRepository.GetByEmailAsync(email);
                if (user == null) return false;

                user.IsEmailConfirmed = true;
                await _userRepository.UpdateAsync(user);
                await _userRepository.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private string GenerateEmailToken(string email)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Email, email),
            new Claim("purpose", "email_confirmation")
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(24),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
