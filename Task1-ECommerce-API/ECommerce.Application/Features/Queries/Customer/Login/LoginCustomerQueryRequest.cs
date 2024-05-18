using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Queries.Customer.Login
{
    public class LoginCustomerQueryRequest:IRequest<LoginCustomerQueryResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
