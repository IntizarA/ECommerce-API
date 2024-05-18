using ECommerce.Infrastructure.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.Infrastructure.AutoMapper;

namespace TaskManagement.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
           services.AddAutoMapper(typeof(MappingProfile));
        }
    }
}
