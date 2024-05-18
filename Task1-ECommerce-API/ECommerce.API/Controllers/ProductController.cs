using ECommerce.Application.DTOs.Product;
using ECommerce.Application.Repositories.Product;
using ECommerce.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerce.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(ProductDTO product)
        {
            await _productService.AddAsync(product);
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
