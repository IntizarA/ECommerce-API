using ECommerce.Application.DTOs.Customer;
using ECommerce.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Queries.Customer.Read
{
    public class GetAllCustomerQueryResponse
    {

        public List<string> Errors { get; set; }
        public List<CustomerDTO> Customers { get; set; }
    }
}
