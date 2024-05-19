using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Queries.Customer.Login
{
    public class LoginCustomerQueryResponse
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors { get; set; }

        public string Token { get; set; }
    }
}
