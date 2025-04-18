using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using Shared.LogInDto;
using Shared.ResponsiesDto;
using Shared.ValidatorCommands;

namespace Presentation.Controllers
{

    [ApiController]
    [Route("api/users")]
    public class UserController(IServiceManager _serviceManager):ControllerBase
    {

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _serviceManager.UserServiec.GetUsers(cancellationToken);

            return Ok(users); 
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisgerUserDto regisgerUserDto)
        {
            await _serviceManager.UserServiec.Register(regisgerUserDto);   
            return Ok();
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LogInDto logInDto)
        { 
            var token = await _serviceManager.UserServiec.Login(logInDto);

            var httpContext = HttpContext.Response.Cookies;
            httpContext.Append("myCookies", token); 

            return Ok(token); 
        }

    }
}
