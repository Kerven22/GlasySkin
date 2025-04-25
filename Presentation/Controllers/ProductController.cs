using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using Shared.CreateDtos;
using Shared.ResponsiesDto;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("/categories")]
    public class ProductController(IServiceManager _serviceManager) : ControllerBase
    {
        [HttpGet("{categoryId:guid}/products")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductResponseDto>))]
        public async Task<IActionResult> GetProducts(Guid categoryId, CancellationToken cancellationToken)
        {
            var products = await _serviceManager.ProductService.GetAllProductAsync(categoryId, trackChanges:false, cancellationToken);
            return Ok(products);
        }

        [HttpPost("{categoryId:guid}/products")]
        public async Task<IActionResult> CreateProduct(Guid categoryId,
            [FromBody] ProductRequestDto requestDto, CancellationToken cancellationToken)
        {
 
            var product = await _serviceManager.ProductService.Create(categoryId, requestDto, trackChanges: false, cancellationToken);

            return Ok(product);
        }
    }
}
