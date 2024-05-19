using ECommerce.Application.Abstraction;
using ECommerce.Application.Abstraction.Repositories.Customer;
using ECommerce.Application.Abstraction.Repositories.Order;
using ECommerce.Application.Abstraction.Repositories.Product;
using ECommerce.Application.Abstraction.Services;
using ECommerce.Persistence.Contexts;
using ECommerce.Persistence.Repositories.Customer;
using ECommerce.Persistence.Repositories.Order;
using ECommerce.Persistence.Repositories.Product;
using ECommerce.Persistence.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistence(this IServiceCollection services)
        {
            services.AddDbContext<ECommerceDbContext>(options => options.UseSqlite(Configuration.ConnectionString));

            //product
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            services.AddScoped<IProductService, ProductService>();

            //customer

            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

            services.AddScoped<ICustomerService, CustomerService>();
            //order
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();


        }
    }
}
