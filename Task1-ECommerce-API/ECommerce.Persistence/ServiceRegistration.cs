using ECommerce.Persistence.Contexts;
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
        }
    }
}
