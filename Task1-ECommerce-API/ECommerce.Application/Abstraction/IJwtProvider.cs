using ECommerce.Application.DTOs.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Abstraction
{
    public interface IJwtProvider
    {
        string Generate(CustomerDTO customer);
    }
}
