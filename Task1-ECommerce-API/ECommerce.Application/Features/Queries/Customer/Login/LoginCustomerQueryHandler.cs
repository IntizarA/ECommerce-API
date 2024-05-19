using ECommerce.Application.Abstraction;
using ECommerce.Application.Abstraction.Services;
using ECommerce.Application.DTOs.Customer;
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
        private readonly IJwtProvider _tokenService;
        public LoginCustomerQueryHandler(ICustomerService userService, IJwtProvider tokenService)
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
                CustomerDTO customerDTO=new CustomerDTO() { UserName=customer.UserName, Password=customer.Password, Id=customer.Id,Email=customer.Email};
                return new LoginCustomerQueryResponse { IsSuccess = true, Token = _tokenService.Generate(customerDTO) };
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
