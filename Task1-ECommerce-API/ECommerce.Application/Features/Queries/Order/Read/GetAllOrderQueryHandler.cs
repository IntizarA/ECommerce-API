using ECommerce.Application.Abstraction.Services;
using ECommerce.Application.DTOs.Order;
using ECommerce.Application.Features.Commands.Order.Create;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;

namespace ECommerce.Application.Features.Queries.Order.Read
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, GetAllOrderQueryResponse>
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<IOrderService> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GetAllOrderQueryHandler(IOrderService orderService, ILogger<IOrderService> logger, IHttpContextAccessor httpContextAccessor)
        {
            _orderService = orderService;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<GetAllOrderQueryResponse> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
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

                var orders = _orderService.Select(customerId, false);

                float total = GetTotalPrice(orders);

                return new()
                {
                    Orders = orders,
                    TotalPrice=total
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

        private float GetTotalPrice(List<OrderDTO?> orders)
        {
            float total = 0;
            foreach (var order in orders)
            {
                total += _orderService.GetPrice(order.OrderDetails);
            }
            return total;
        }
    }
}
