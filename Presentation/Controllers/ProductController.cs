using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using Shared.CreateDtos;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("/categories")]
    public class ProductController(IServiceManager _serviceManager) : ControllerBase
    {
        [HttpGet("products")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _serviceManager.ProductService.GetAllProductAsync();
            return Ok(products);
        }

        [HttpPost("products/create")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequestDto responseDto)
        {
            var product = await _serviceManager.ProductService.Create(responseDto, trackChanges: false);

            return Ok(product);
        }
    }
}
