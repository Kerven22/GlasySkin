using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using Shared.LogInDto;
using Shared.ValidatorCommands;

namespace Presentation.Controllers
{

    [ApiController]
    [Route("api/users")]
    public class UserController(IServiceManager _serviceManager):ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisgerUserDto regisgerUserDto)
        {
            await _serviceManager.UserServiec.Register(regisgerUserDto);   
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> Login([FromQuery] LogInDto logInDto)
        { 
            var token = await _serviceManager.UserServiec.Login(logInDto);

            var httpContext = HttpContext.Response.Cookies;
            httpContext.Append("myCookies", token); 

            return Ok(); 
        }

    }
}
