using InventoryManagementProject.Core.Models;
using InventoryMangementProject.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProd()
        {
            var products = await productService.GetAllProducts();
            if (products == null)
            {
                return NotFound();
            }
            return Ok(products);
        }
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProdById(int productId)
        {
            var category = await productService.GetProductById(productId);
            if (category != null)
            {
                return Ok(category);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateProd(Product prod)
        {
            var isProdCreated = await productService.CreateProduct(prod);
            if (isProdCreated)
            {
                return Ok(isProdCreated);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProd(Product prod)
        {
            if (prod != null)
            {
                var isProdCreated = await productService.UpdateProduct(prod);
                if (isProdCreated)
                {
                    return Ok(isProdCreated);
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProd(int id)
        {
            var isProdDeleted = await productService.DeleteProduct(id);
            if (isProdDeleted)
            {
                return Ok(isProdDeleted);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
