using ECommerce.Domain.Entities;
using ECommerce.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Contexts
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasMany(customer => customer.Orders).WithOne(order => order.Customer).HasForeignKey(customer => customer.CustomerId);
            modelBuilder.Entity<Order>().HasMany(order => order.OrderDetails).WithOne(orderDetail => orderDetail.Order).HasForeignKey(order => order.OrderId);
            modelBuilder.Entity<Product>().HasMany(product => product.OrderDetails).WithOne(orderDetail => orderDetail.Product).HasForeignKey(product => product.ProductId);
            base.OnModelCreating(modelBuilder);
        }

        DbSet<Customer> Customers { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }

        public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            try
            {
                var data = ChangeTracker.Entries<BaseEntity>();
                foreach (var datum in data)
                {
                    _ = datum.State switch
                    {
                        EntityState.Added=>datum.Entity.CreatedDate=DateTime.UtcNow,
                        EntityState.Modified=>datum.Entity.UpdatedDate=DateTime.UtcNow
                    };
                }
                return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
