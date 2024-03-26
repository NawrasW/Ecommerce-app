using Ecommerce.Server.Models.Domain;
using Ecommerce.Server.Models.Dtos;
using Ecommerce.Server.Repsitories.Abstrarct;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepsitory _repsitory;

        public ProductController(IProductRepsitory repsitory)
        {
            _repsitory = repsitory;
        }


        [HttpGet("getProductById/{id}")]

        public async Task<IActionResult> getProductById(int id)
        {

            var result = await _repsitory.GetById(id);
            if (result == null)
            {
                var status = new Status
                {
                    StatusCode = 0,
                    StatusMessage = "Product Not Found"

                };
                return Ok(status);


            }
            return Ok(result);
        }


        [HttpGet("getAll")]
        public async Task<IActionResult> GetAllProducts()

        {
            var result = await _repsitory.GetAll();
            return Ok(result);
        }

        [HttpPost("addProduct")]

        public async Task<IActionResult> AddProduct(Product Product)
        {
            var result = await _repsitory.AddUpdate(Product);
            var status = new Status
            {

                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Add Successfully" : "Error adding......."


            };
            return Ok(status);
        }



        [HttpPut("updateProduct")]

        public async Task<IActionResult> UpdateProduct(Product Product)
        {
            var result = await _repsitory.AddUpdate(Product);
            var status = new Status
            {

                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Updated Successfully" : "Error Updating......."


            };
            return Ok(status);
        }



        [HttpDelete("deleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _repsitory.Delete(id);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Deleted Successfully" : "Error Deleting......"

            };
            return Ok(status);
        }


        [HttpGet("getProductsByCategoryId/{categoryId}")]
        public async Task<IActionResult> GetProductsByCategoryId(int categoryId)

        {
            var result = await _repsitory.GetProductsByCategoryId(categoryId);
            return Ok(result);
        }



    }

}

