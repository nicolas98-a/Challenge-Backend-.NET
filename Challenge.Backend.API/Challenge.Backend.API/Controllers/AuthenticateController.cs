using Challenge.Backend.API.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Backend.API.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManeger;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(UserManager<ApplicationUser> userManeger, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManeger = userManeger;
            this.roleManager = roleManager;
            _configuration = configuration;
        }

        /// <summary>
        /// Permite loguear un usuario registrado
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Retorna un token y cuando expira</returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await userManeger.FindByNameAsync(model.Username);
            if (user != null)
            {
                if (await userManeger.CheckPasswordAsync(user, model.Password))
                {
                    var userRoles = await userManeger.GetRolesAsync(user);
                    var authClaims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    };

                    foreach (var userRol in userRoles)
                    {
                        authClaims.Add(new Claim(ClaimTypes.Role, userRol));
                    }

                    var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                    var token = new JwtSecurityToken(
                        issuer: _configuration["JWT:ValidIssuer"],
                        audience: _configuration["JWT:ValidAudience"],
                        expires: DateTime.Now.AddHours(3),
                        claims: authClaims,
                        signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256));

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
                return BadRequest(new Response { Status = "Error", Message = "Contraseña incorrecta" });
            }

            return BadRequest(new Response { Status = "Error", Message = "Usuario no registrado" });
        }

        /// <summary>
        /// Permite registrar un nuevo usuario
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Retorna un mensaje de registro satisfactorio</returns>
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await userManeger.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "El usuario ya existe!" });
            }

            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            var result = await userManeger.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                string errors = "";
                foreach (var item in result.Errors.ToList())
                {
                    errors += item.Description.ToString();
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = $"Falla al crear usuario! Chequee los datos del usuario e intenlo de nuevo. Errores: {errors}" });
            }

            return Ok(new Response { Status = "Success", Message = "Usuario creado correctamente" });
        }
    }
}
