using ECommerce.Application.DTOs.Order;
using ECommerce.Application.Features.Commands.Order.Create;
using ECommerce.Application.Features.Queries.Order.Read;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace ECommerce.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("authorized")]
        [Authorize]
        public async Task<IActionResult> PlaceOrder(CreateOrderCommandRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception exception)
            {
                return StatusCode(500, $"Unexpected error, please try again later! exception {exception.Message}");
            }

        }

        [HttpGet("authorized")]
        [Authorize]
        public async Task<IActionResult> GetOrders(GetAllOrderQueryRequest request)
        {
            try
            {
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception exception)
            {
                return StatusCode(500, $"Unexpected error, please try again later! exception {exception.Message}");
            }
        }

    }
}
