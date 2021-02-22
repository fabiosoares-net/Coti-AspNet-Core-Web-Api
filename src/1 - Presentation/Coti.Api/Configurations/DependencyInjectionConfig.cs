using Microsoft.Extensions.DependencyInjection;
using System;

namespace Coti.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            Infrastructure.Injector.NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
