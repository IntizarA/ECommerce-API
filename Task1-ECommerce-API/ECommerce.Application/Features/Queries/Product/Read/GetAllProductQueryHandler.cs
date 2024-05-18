using ECommerce.Application.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Queries.Product.Read
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, GetAllProductQueryResponse>
    {
        private readonly IProductService _productService;
        private readonly ILogger<IProductService> _logger;
        public GetAllProductQueryHandler(IProductService productService, ILogger<IProductService> logger)
        {
            _productService = productService;
            _logger = logger;
        }
        public async Task<GetAllProductQueryResponse> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var products = _productService.GetAll(false).Skip(request.Page * request.Size).Take(request.Size).ToList();
                return new()
                {
                    Products = products,
                };
            }
            catch (Exception exception)
            {
                string message = "An error occurred while handling the CreateProductCommand.";
                _logger.LogError(exception, message);

                message += $" {exception.Message}";
                return new()
                {
                    Errors = new List<string>()
                    {
                       message
                    }
                };
            }
        }
    }
}
