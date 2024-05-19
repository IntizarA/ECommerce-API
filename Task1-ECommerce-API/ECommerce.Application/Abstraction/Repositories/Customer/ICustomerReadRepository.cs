using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Application.Abstraction.Repositories;

namespace ECommerce.Application.Abstraction.Repositories.Customer
{
    public interface ICustomerReadRepository : IReadRepository<Domain.Entities.Customer>
    {
    }
}
