using Ecommerce.Server.Models.Domain;
using Ecommerce.Server.Models.Dtos;
using Ecommerce.Server.Repsitories.Abstrarct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepsitory _categoryRepsitory;

        public CategoryController(ICategoryRepsitory repository)
        {
            _categoryRepsitory = repository;
        }

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _categoryRepsitory.GetAllCategory();
            return Ok(result);
        }

        [HttpGet("getAllCategoryLookup")]
        public async Task<IActionResult> GetAllCategoryLookup()
        {
            var result = await _categoryRepsitory.GetAllCategoryLookup();
            return Ok(result);
        }

        [HttpGet("getById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _categoryRepsitory.GetCategoryById(id);
            return Ok(result);
        }

        [HttpPost("AddUpdate")]
        public async Task<IActionResult> AddUpdate(Category category)
        {
            var result = await _categoryRepsitory.AddUpdateCategory(category);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Saved Category Successfully" : "Error Updating......."
            };
            return Ok(status);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryRepsitory.DeleteCategory(id);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Deleted Category Successfully" : "Error Deleting......"
            };
            return Ok(status);
        }

        [HttpGet("getCategories")]
        public async Task<IActionResult> GetCategoryLookup()
        {
            var result = await _categoryRepsitory.GetCategories();
            return Ok(result);
        }
    }
}
