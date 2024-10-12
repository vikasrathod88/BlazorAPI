using BlazorAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
     {

        private readonly IConfiguration _configuration;
        private readonly BlazorDbContext _context;

        public AuthController(IConfiguration configuration, BlazorDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost("login")]

        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            if (string.IsNullOrEmpty(loginModel.UserName) || !string.IsNullOrEmpty(loginModel.Password))
            {
                return BadRequest("Username or password cannot be null.");
            }


       
             var user = _context.BlazorDatas.FirstOrDefault(u => u.FNAME == loginModel.UserName && u.PASSWORD == loginModel.Password);
           // var user = _context.Employees.FirstOrDefault(u => u.Phone == loginModel.User && u.Email == loginModel.Password);

            Console.WriteLine(user);

            if (user != null)
            {
                // Generate JWT token with claims from the database
                var token = GenerateJwtToken(user);
                return Ok(token);
            }
            else
            {
                return Unauthorized("Invalid username or password.");
            }
           
        }

        private string GenerateJwtToken(BlazorData user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.FNAME),
       // new Claim(ClaimTypes.Email, user.EMAIL),
        new Claim(ClaimTypes.Role, "Admin")
    };


            // Add role claims based on user role in the database
            //if (user.Role == "Admin")
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            //}
            //else if (user.Role == "Executive")
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, "Executive"));
            //}


            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }



    }
}
