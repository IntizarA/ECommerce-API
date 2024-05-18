using ECommerce.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Queries.Customer.Login
{
    public class LoginCustomerQueryHandler : IRequestHandler<LoginCustomerQueryRequest, LoginCustomerQueryResponse>
    {
        private readonly ICustomerService _customerService;
        private readonly ITokenService _tokenService;
        public LoginCustomerQueryHandler(ICustomerService userService, ITokenService tokenService)
        {
            _customerService = userService;
            _tokenService = tokenService;
        }
        public async Task<LoginCustomerQueryResponse> Handle(LoginCustomerQueryRequest request, CancellationToken cancellationToken)
        {
            var customer = await _customerService.SingleOrDefaultAsync(request.UserName,false);

            if (customer==null)
            {
                return new LoginCustomerQueryResponse
                {
                    IsSuccess = false,
                    Errors = new()
                {
                    "User does not exist!"
                }
                };
            }


            if (BCrypt.Net.BCrypt.Verify(request.Password, customer.Password))
            {
                return new LoginCustomerQueryResponse { IsSuccess = true, Token = _tokenService.CreateToken(request.UserName) };
            }

            return new LoginCustomerQueryResponse
            {
                IsSuccess = false,
                Errors = new()
            {
                "Email or password is incorrect"
            }
            };
        }
    }
}
