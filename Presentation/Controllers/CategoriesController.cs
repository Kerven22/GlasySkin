using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Contract;
using Shared.CreateDtos;
using Shared.ResponsiesDto;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController(IServiceManager _serviceManager) : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(CategoryResponseDto[]))]

        public async Task<IActionResult> GetCategories()
        {
            var categories = await _serviceManager.CategoryService.GetAllCategories(trackChanges: false);

            return Ok(categories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryRequestDto requestDto)
        {
            var category = await _serviceManager.CategoryService.CreateCategoryAsync(requestDto); 

            return Ok(category); 
        }
    }
}
