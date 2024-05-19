using ECommerce.Application.Abstraction.Services;
using ECommerce.Application.DTOs.Order;
using ECommerce.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Commands.Order.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest, CreateOrderCommandResponse>
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<IOrderService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CreateOrderCommandHandler(IOrderService orderService, ILogger<IOrderService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _orderService = orderService;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateOrderCommandResponse> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                string? customerId = GetCustomerId();

                if (customerId == null)
                    return new()
                    {
                        Errors = new List<string>()
                    {
                    "Unable to retrieve customer ID from token."
                    }
                    };


                OrderDTO order = new()
                {
                    CustomerId = customerId,
                    OrderStatus = Domain.Enums.OrderStatus.Processing,
                    OrderDetails = request.OrderDetails
                };
                bool isAdded = await _orderService.AddAsync(order);
                return new CreateOrderCommandResponse()
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

        private string? GetCustomerId()
        {
            string? token = _httpContextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            if (token == null)
                return null;

            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(token);

            var customerIdClaim = decodedToken.Subject;

            if (customerIdClaim != null)
            {
                var userId = customerIdClaim;
                return userId;
            }
            return null;
        }
    }
}
