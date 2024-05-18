using ECommerce.Application.DTOs.Product;
using ECommerce.Application.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ECommerce.Application.Features.Commands.Product.Create
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest, CreateProductCommandResponse>
    {
        private readonly IProductService _productService;
        private readonly ILogger<IProductService> _logger;
        public CreateProductCommandHandler(IProductService productService, ILogger<IProductService> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        public async Task<CreateProductCommandResponse> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                ProductDTO productDTO = new()
                {
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    Stock = request.Stock
                };
                bool isAdded = await _productService.AddAsync(productDTO);
                return new()
                {
                    IsSuccess = isAdded
                };
            }
            catch (Exception exception)
            {
                string message = "An error occurred while handling the CreateProductCommand.";
                _logger.LogError(exception, message);

                message += $" {exception.Message}";
                return new()
                {
                    IsSuccess = false,
                    Errors = new List<string>()
                    {
                       message
                    }
                };
            }

        }
    }
}
