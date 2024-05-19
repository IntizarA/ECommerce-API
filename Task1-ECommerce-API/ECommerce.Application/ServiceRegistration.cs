using ECommerce.Application.Features.Commands.Customer.Create;
using ECommerce.Application.Features.Commands.Order.Create;
using ECommerce.Application.Features.Commands.Product.Create;
using ECommerce.Application.Features.Commands.Product.Remove;
using ECommerce.Application.Features.Commands.Product.Update;
using ECommerce.Application.Features.Queries.Customer.Login;
using ECommerce.Application.Features.Queries.Customer.Read;
using ECommerce.Application.Features.Queries.Order.Read;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(config =>
            {
                //product
                config.RegisterServicesFromAssemblyContaining<CreateProductCommandHandler>();
                config.RegisterServicesFromAssemblyContaining<UpdateProductCommandHandler>();
                config.RegisterServicesFromAssemblyContaining<RemoveProductCommandHandler>();

                //customer
                config.RegisterServicesFromAssemblyContaining<CreateCustomerCommandHandler>();
                config.RegisterServicesFromAssemblyContaining<LoginCustomerQueryHandler>();
                config.RegisterServicesFromAssemblyContaining<GetAllCustomerQueryHandler>();

                //order
                config.RegisterServicesFromAssemblyContaining<CreateOrderCommandHandler>();
                config.RegisterServicesFromAssemblyContaining<GetAllOrderQueryHandler>();

                services.AddHttpContextAccessor();

            });
        }
    }
}
