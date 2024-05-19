using ECommerce.Application.DTOs.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace ECommerce.API.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public IActionResult PlaceOrder(OrderDTO order)
        {
            var token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

            var handler = new JwtSecurityTokenHandler();
            var decodedToken = handler.ReadJwtToken(token);

            var userIdClaim = decodedToken.Subject;

            if (userIdClaim != null)
            {
                var userId = userIdClaim;
                return Ok($"User ID from token: {userId}");
            }

            return Ok(true);
        }
    }
}
