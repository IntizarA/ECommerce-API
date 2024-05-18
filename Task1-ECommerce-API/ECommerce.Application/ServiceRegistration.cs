using ECommerce.Application.Features.Commands.Product.Create;
using ECommerce.Application.Features.Commands.Product.Remove;
using ECommerce.Application.Features.Commands.Product.Update;
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
                config.RegisterServicesFromAssemblyContaining<CreateProductCommandHandler>();
                config.RegisterServicesFromAssemblyContaining<UpdateProductCommandHandler>();
                config.RegisterServicesFromAssemblyContaining<RemoveProductCommandHandler>();

            });
        }
    }
}
