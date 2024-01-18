using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using JwtoAuth.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt; 

namespace API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AuthController :ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _Config;

        public AuthController(IConfiguration config) 
        {
            _Config = config;
        }

        [HttpPost("Register")]
        public ActionResult<User> Register(UserDto request)
        {
            string PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            user.UserName = request.UserName;
            user.PasswordHash = PasswordHash;

            return Ok(user);
        }
        [HttpPost("Login")]
        public ActionResult<User> Login(UserDto request)
        {
            if (user.UserName != request.UserName)
            {
                return BadRequest("User Name Not Found");
            }
            if (!BCrypt.Net.BCrypt.Verify(request.Password,user.PasswordHash))
            {
                return BadRequest("Wrong Password");
            }
            string token = CreateToken(user);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.UserName!),
                //  new Claim(ClaimTypes.Role,"Admin"),
                //  new Claim(ClaimTypes.Role,"User")
                

            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _Config.GetSection("AppSettings:Token").Value!));
            
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token =  new JwtSecurityToken(
                claims : claims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials:credentials
            );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;

        }
    }
}