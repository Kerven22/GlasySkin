using Microsoft.AspNetCore.Mvc;
using Service.Contract;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/types")]
    public class TypesController(IServiceManager _serviceManager):ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetTypes()
        {
            var types = await _serviceManager.TypeService.GetAllProductTypes(trackChanges: false);

            return Ok(types);
        }
    }
}
