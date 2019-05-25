using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentApp.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentApp.Data.Extensions
{
    public static class DataServiceExtension
    {
        public static IServiceCollection AddDataExtension(this IServiceCollection services, string connectionStringName, string migrationAssemblyName)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            services = services.AddScoped(sp =>
              new StudentAppContext(configuration.GetConnectionString(connectionStringName), migrationAssemblyName)
            );

            services = services.AddDbContext<StudentAppContext>(options =>
               options.UseSqlServer(
                    configuration.GetConnectionString(connectionStringName),
                    b => b.MigrationsAssembly(migrationAssemblyName)
               ));


            return services;
        }
    }
}
