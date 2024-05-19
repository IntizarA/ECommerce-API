using ECommerce.Application.Abstraction.Services;
using ECommerce.Application.Features.Queries.Product.Read;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Queries.Customer.Read
{
    public class GetAllCustomerQueryHandler : IRequestHandler<GetAllCustomerQueryRequest, GetAllCustomerQueryResponse>
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<IProductService> _logger;
        public GetAllCustomerQueryHandler(ICustomerService customerService, ILogger<IProductService> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        public async Task<GetAllCustomerQueryResponse> Handle(GetAllCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customers = _customerService.GetAll(false);
                return new()
                {
                    Customers = customers,
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
