using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Queries.Customer.Read
{
    public class GetAllCustomerQueryRequest:IRequest<GetAllCustomerQueryResponse>
    {
    }
}
