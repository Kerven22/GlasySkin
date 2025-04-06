using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using Shared.ResponsiesDto;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/types")]    
    public class TypesController(IServiceManager _serviceManager):ControllerBase
    {
        
        [HttpGet]
        [Authorize]
        [ProducesResponseType(200, Type = typeof(TypeResponseDto[]))]
        public async Task<IActionResult> GetTypes()
        {
            var types = await _serviceManager.TypeService.GetAllProductTypes(trackChanges: false);

            return Ok(types);
        }
    }
}
