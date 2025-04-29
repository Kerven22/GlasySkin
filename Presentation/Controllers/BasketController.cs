using Microsoft.AspNetCore.Mvc;
using Service.Contract;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("basket")]
    public class BasketController(IServiceManager _serviceManager):ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBasket(Guid basketId)
        {
            var basket = await _serviceManager.BacketService.GetBasket(basketId);
            return Ok(basket); 
        }
    }
}
