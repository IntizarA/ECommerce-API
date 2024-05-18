using ECommerce.Application.DTOs.Product;
using ECommerce.Application.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Commands.Product.Remove
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommandRequest, RemoveProductCommandResponse>
    {
        private readonly IProductService _productService;
        private readonly ILogger<IProductService> _logger;
        public RemoveProductCommandHandler(IProductService productService, ILogger<IProductService> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        public async Task<RemoveProductCommandResponse> Handle(RemoveProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                bool isRemoved = _productService.RemoveById(request.Id);
                return new()
                {
                    IsSuccess = isRemoved
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
