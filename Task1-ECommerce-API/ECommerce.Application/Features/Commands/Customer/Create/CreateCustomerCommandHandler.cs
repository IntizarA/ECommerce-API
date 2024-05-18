using ECommerce.Application.DTOs.Customer;
using ECommerce.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Commands.Customer.Create
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommandRequest, CreateCustomerCommandResponse>
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<ICustomerService> _logger;
        public CreateCustomerCommandHandler(ICustomerService customerService, ILogger<ICustomerService> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        public async Task<CreateCustomerCommandResponse> Handle(CreateCustomerCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _customerService.SingleOrDefaultAsync(request.UserName, false);
                if (customer != null)
                {
                    return new()
                    {
                        IsSuccess = false,
                        Errors = new()
                    {
                        "This email is already connected to another account"
                    }
                    };
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(request.Password);

                CustomerDTO customerDTO = new()
                {
                    UserName = request.UserName,
                    Email = request.Email,
                    Password = hashedPassword
                };

                bool isSuccess = await _customerService.AddAsync(customerDTO);
                return new()
                {
                    IsSuccess = true
                };
            }
            catch (Exception exception)
            {
                string message = "An error occurred while handling the CreateCustomerCommand.";
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
