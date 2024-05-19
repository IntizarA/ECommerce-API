using ECommerce.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application.Abstraction.Repositories
{
    public interface IReadRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll(bool isTracking);
        T? GetById(string id, bool isTracking);
        Task<T?> GetByIdAsync(string id, bool isTracking);
        IQueryable<T?> Select(Expression<Func<T, bool>> expression, bool isTracking);
        Task<bool> IsExists(Expression<Func<T, bool>> expression, bool isTracking);

        Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, bool isTracking);
    }
}
