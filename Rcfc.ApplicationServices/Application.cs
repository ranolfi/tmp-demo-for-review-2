using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

using Rcfc.Domain.Interfaces.DataPersistence.DataRepositories;
using Rcfc.ApplicationServices.Services;
using Rcfc.DataPersistence.DataSources.Postgres_Rcfc;
using Rcfc.DataPersistence.DataRepositories;

namespace Rcfc.ApplicationServices
{
    public static class Application
    {
        private const string MainDbEFConnectionStringName = "Postgres_Rcfc";

        public static void RegisterServices(IServiceCollection services)
        {
            // TODO: Use MediatR

            services.AddScoped<UserService>();
        }

        // TODO: register repository instead of DbContext?
        // TODO: Make sure this method is not called for pages that don't need to query the DB
        public static void RegisterDbContext(IServiceCollection services)
        {
            
        }

        public static IServiceCollection RegisterDataRepositories(IServiceCollection services)
        {
            return services.AddScoped<IUserRepository, UserRepository>(serviceProvider =>
                { 
                    IConfiguration configuration = GetConfiguration();
                    services.AddDbContext<EntityFrameworkContext>(options =>
                    options.UseNpgsql( configuration.GetConnectionString(MainDbEFConnectionStringName) )
                    );
                    EntityFrameworkContext dbContext = serviceProvider.GetRequiredService<EntityFrameworkContext>();
                    return new UserRepository(dbContext);
                }
            );
        }

        public static IServiceCollection RegisterDataContext (IServiceCollection services)
        {
            return services.AddScoped<IDataContext, DataContext>(serviceProvider =>
                { 
                    IConfiguration configuration = GetConfiguration();
                    services.AddDbContext<EntityFrameworkContext>(options =>
                    options.UseNpgsql( configuration.GetConnectionString(MainDbEFConnectionStringName) )
                    );
                    EntityFrameworkContext dbContext = serviceProvider.GetRequiredService<EntityFrameworkContext>();
                    return new DataContext(dbContext);
                }
            );
        }

        internal static IConfiguration GetConfiguration()
        {
            // See:
            // https://docs.microsoft.com/en-us/dotnet/core/extensions/configuration-providers#json-configuration-provider
            // https://www.ttmind.com/techpost/How-to-read-appSettings-JSON-from-Class-Library-in-ASP-NET-Core

            //IHostEnvironment env = hostingContext.HostingEnvironment;
            var configurationBuilder = new ConfigurationBuilder();
            //var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"); //using System.IO;
            configurationBuilder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, true);

            IConfigurationRoot configurationRoot = configurationBuilder.Build();
            IConfiguration configuration = configurationRoot;
            return configuration;
        }
    }
}
