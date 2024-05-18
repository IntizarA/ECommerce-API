using ECommerce.Application.DTOs.Product;
using ECommerce.Application.Features.Commands.Product.Create;
using ECommerce.Application.Features.Commands.Product.Remove;
using ECommerce.Application.Features.Commands.Product.Update;
using ECommerce.Application.Repositories.Product;
using ECommerce.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;

namespace ECommerce.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductCommandRequest request)
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

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProductCommandRequest request)
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

        [HttpDelete]
        public async Task<IActionResult> Remove(RemoveProductCommandRequest request)
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
