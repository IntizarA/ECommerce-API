using ECommerce.Application.Repositories;
using ECommerce.Domain.Entities.Common;
using ECommerce.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        public readonly ECommerceDbContext _context;

        public ReadRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool isTracking)
        {
            IQueryable<T> query = CheckTracking(isTracking);
            return query;
        }

        public T? GetById(string id, bool isTracking)
        {
            IQueryable<T> query = CheckTracking(isTracking);
            return query.FirstOrDefault(data => data.Id == Guid.Parse(id));
        }

        public async Task<T?> GetByIdAsync(string id, bool isTracking)
        {
            try
            {
                IQueryable<T> query = CheckTracking(isTracking);
                return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
            }
            catch (DbUpdateException dbException)
            {
                return null;
            }
            catch (Exception ex)
            {
                // other exceptions 
                return null;
            }

        }

        public IQueryable<T?> Select(Expression<Func<T, bool>> expression, bool isTracking)
        {
            IQueryable<T> query = CheckTracking(isTracking);
            return query.Where(expression);
        }

        public IQueryable<T> CheckTracking(bool isTracking)
        {
            IQueryable<T> query = Table.AsQueryable();
            if (!isTracking)
            {
                query = Table.AsNoTracking();
            }
            return query;
        }

        public async  Task<bool> IsExists(Expression<Func<T, bool>> expression, bool isTracking)
        {
            IQueryable<T> query = CheckTracking(isTracking);
            return await query.AnyAsync(expression);
        }

    }
}
