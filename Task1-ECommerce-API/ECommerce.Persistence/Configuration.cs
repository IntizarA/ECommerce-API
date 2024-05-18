using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence
{
    public static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Task1-ECommerce-API/ECommerce.API"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("SQLite3");
            }
        }
    }
}
