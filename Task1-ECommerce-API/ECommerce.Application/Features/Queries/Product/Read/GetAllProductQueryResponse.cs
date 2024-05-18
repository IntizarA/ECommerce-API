using ECommerce.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Queries.Product.Read
{
    public class GetAllProductQueryResponse
    {
        public List<string> Errors { get; set; }
        public List<ProductDTO> Products { get; set; }

    }
}
