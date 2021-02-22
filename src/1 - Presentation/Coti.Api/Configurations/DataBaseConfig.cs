using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Coti.Api.Configurations
{
    public static class DataBaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<Coti.Infrastructure.Context.Base.CotiContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DB")));
        }
    }
}
