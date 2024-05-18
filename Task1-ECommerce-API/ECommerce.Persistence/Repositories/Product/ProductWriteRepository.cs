using ECommerce.Application.Repositories.Product;
using ECommerce.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Repositories.Product
{
    public class ProductWriteRepository : WriteRepository<Domain.Entities.Product>, IProductWriteRepository
    {
        public ProductWriteRepository(ECommerceDbContext context) : base(context)
        {
        }
    }
}
