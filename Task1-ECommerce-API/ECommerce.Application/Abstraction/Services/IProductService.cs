using ECommerce.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Abstraction.Services
{
    public interface IProductService
    {
        bool Add(ProductDTO product);
        Task<bool> AddAsync(ProductDTO product);
        bool AddRange(List<ProductDTO> range);
        Task<bool> AddRangeAsync(List<ProductDTO> range);
        bool Update(ProductUpdateDTO product);
        bool Remove(ProductRemoveDTO product);
        bool RemoveById(string id);
        bool RemoveRange(List<ProductRemoveDTO> range);

        List<ProductDTO> GetAll(bool isTracking);
        ProductDTO? GetById(string id, bool isTracking);
        Task<ProductDTO?> GetByIdAsync(string id, bool isTracking);
        List<ProductDTO?> Select(Expression<Func<ProductDTO, bool>> expression, bool isTracking);
    }
}
