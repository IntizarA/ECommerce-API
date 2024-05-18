using ECommerce.Application.Repositories.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerce.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProductWriteRepository _writeRepository;
        public readonly IProductReadRepository _readRepository;

        public ProductController(IProductWriteRepository writeRepository, IProductReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(Domain.Entities.Product product)
        {
            _writeRepository.Add(product);
            await _writeRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }
    }
}
