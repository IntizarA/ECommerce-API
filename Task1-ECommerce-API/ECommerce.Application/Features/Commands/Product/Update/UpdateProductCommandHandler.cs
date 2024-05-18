using ECommerce.Application.DTOs.Product;
using ECommerce.Application.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Commands.Product.Update
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        private readonly IProductService _productService;
        private readonly ILogger<IProductService> _logger;
        public UpdateProductCommandHandler(IProductService productService, ILogger<IProductService> logger)
        {
            _productService = productService;
            _logger = logger;
        }


        public async  Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                ProductUpdateDTO productDTO = new()
                {
                    Id = request.Id,
                    Name = request.Name,
                    Description = request.Description,
                    Price = request.Price,
                    Stock = request.Stock
                };
                bool isUpdated =  _productService.Update(productDTO);
                return new()
                {
                    IsSuccess = isUpdated
                };
            }
            catch (Exception exception)
            {
                string message = "An error occurred while handling the UpdateProductCommandResponse.";
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
