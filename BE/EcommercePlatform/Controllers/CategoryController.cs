using EcommercePlatform.DTOs.RequestDTO;
using EcommercePlatform.DTOs.ResponseDTO;
using EcommercePlatform.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcommercePlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDTO createCategoryDTO) {
            try
            {
                var rs = await _categoryService.AddCategoryAsync(createCategoryDTO);
                return Ok(rs);
            } catch (Exception ex) { 
                return BadRequest(new { ex.Message });
            }
        }
        [HttpGet("get-list-category")]
        public async Task<IActionResult> GetListCategory()
        {
            try
            {
                var rs = await _categoryService.GetListCategory();
                return Ok(rs);
            }
            catch(Exception ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}
