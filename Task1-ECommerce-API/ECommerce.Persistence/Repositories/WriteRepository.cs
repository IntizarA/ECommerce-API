using ECommerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Persistence.Contexts;
using ECommerce.Application.Abstraction.Repositories;

namespace ECommerce.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        public readonly ECommerceDbContext _context;

        public WriteRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public bool Add(T entity)
        {
            EntityEntry<T> entityEntry = _context.Add(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddAsync(T entity)
        {
            try
            {
                EntityEntry<T> entityEntry = await _context.AddAsync(entity);
                return entityEntry.State == EntityState.Added;
            }
            catch (DbUpdateException dbException)
            {
                return false;
            }
            catch (Exception exception)
            {
                return false;
            }

        }

        public bool AddRange(List<T> range)
        {
            //_context.AddRange(range);
            foreach (T entity in range)
            {
                EntityEntry<T> entityEntry = _context.Add(entity);
                if (entityEntry.State != EntityState.Added)
                    return false;
            }
            return true;
        }

        public async Task<bool> AddRangeAsync(List<T> range)
        {
            try
            {
                //_context.AddRangeAsync(range);
                foreach (T entity in range)
                {
                    EntityEntry<T> entityEntry = await _context.AddAsync(entity);
                    if (entityEntry.State != EntityState.Added)
                        return false;
                }
                return true;
            }
            catch (DbUpdateException dbException)
            {
                return false;
            }
            catch (Exception exception)
            {
                return false;
            }


        }

        public bool Remove(T entity)
        {
            EntityEntry entityEntry = _context.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveById(string id)
        {
            T? entity = Table.FirstOrDefault(data => data.Id == Guid.Parse(id));
            if (entity == null)
                return false;
            EntityEntry entityEntry = _context.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<T> range)
        {
            //_context.RemoveRange(range);

            foreach (T entity in range)
            {
                EntityEntry entityEntry = _context.Remove(entity);

                if (entityEntry.State != EntityState.Deleted)
                    return false;

            }
            return true;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                return -1;
            }
        }

        public bool Update(T entity)
        {
            EntityEntry entityEntry = _context.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }
    }
}
