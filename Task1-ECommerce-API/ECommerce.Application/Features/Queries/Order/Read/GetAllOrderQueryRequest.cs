using MediatR;

namespace ECommerce.Application.Features.Queries.Order.Read
{
    public class GetAllOrderQueryRequest:IRequest<GetAllOrderQueryResponse>
    {
    }
}
