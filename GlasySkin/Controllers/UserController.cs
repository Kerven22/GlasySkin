using GlasySkin.AuthentificationExtentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace GlasySkin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Welcome my page");
        }
        [HttpGet("hello")]
        [Authorize]
        public IActionResult GetHello()
        {
            return Ok("you are authorized!"); 
        }

        [HttpGet("login/{userName}")]
        public IActionResult GetLogin(string userName)
        {
            var claims = new List<Claim> { new Claim ( ClaimTypes.Name, userName ) };
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return Ok(new JwtSecurityTokenHandler().WriteToken(jwt)); 
        }
    }
}
