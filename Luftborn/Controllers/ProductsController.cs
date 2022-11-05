using Luftborn.Dtos;
using Luftborn.Models;
using Luftborn.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Luftborn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _productService.GetAllProductsAsync();
            return Ok(response);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> PostProduct(CreateProductDto product)
        {
            var response = new ResponseModel();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                response = await _productService.CreateProductAsync(product);
                return Created(nameof(GetAllProducts), product);
            }
            catch (Exception ex)
            {
                 response.AddError(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto product)
        {
            var response = new ResponseModel();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                response = await _productService.UpdateProductAsync(product);
                if(response.Success)
                    return Created(nameof(GetAllProducts), product);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
                return BadRequest(response);
            }
        }

        [HttpDelete("DeleteProduct{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = new ResponseModel();
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                response = await _productService.DeleteProductAsync(id);
                if (response.Success)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                response.AddError(ex.Message);
                return BadRequest(response);
            }
        }
    }
}
