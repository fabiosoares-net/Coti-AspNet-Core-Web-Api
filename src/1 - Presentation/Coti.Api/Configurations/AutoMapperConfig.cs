using System;
using AutoMapper;
using Coti.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Coti.Api.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToModelMappingProfile), typeof(ModelToDomainMappingProfile));
        }
    }
}
