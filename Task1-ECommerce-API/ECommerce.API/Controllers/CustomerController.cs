using ECommerce.Application.Features.Commands.Customer.Create;
using ECommerce.Application.Features.Queries.Customer.Login;
using ECommerce.Application.Features.Queries.Customer.Read;
using ECommerce.Application.Features.Queries.Product.Read;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("registr")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommandRequest request)
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

        [HttpPost("login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginCustomerQueryRequest request, CancellationToken cancellationToken)
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


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCustomerQueryRequest request)
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
