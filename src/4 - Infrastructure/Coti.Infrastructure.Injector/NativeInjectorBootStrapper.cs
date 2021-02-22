using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Coti.Infrastructure.Injector
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<Coti.Infrastructure.Context.Base.CotiContext>();
            services.AddScoped<Coti.Domain.Interface.Repository.IUnitOfWork, Coti.Infrastructure.Data.UnitOfWork>();

            #region Application
            services.AddScoped<Coti.Application.Interface.IFuncionarioApplicationService, Coti.Application.Service.FuncionarioApplicationService>();
            services.AddScoped<Coti.Application.Interface.IDependenteApplicationService, Coti.Application.Service.DependenteApplicationService>();
            services.AddScoped<Coti.Application.Interface.IUsuarioApplicationService, Coti.Application.Service.UsuarioApplicationService>();

            #endregion

            #region Domain
            services.AddScoped<Coti.Domain.Interface.Service.IDependenteDomainService, Coti.Domain.Services.DependenteDomainService>();
            services.AddScoped<Coti.Domain.Interface.Service.IFuncionarioDomainService, Coti.Domain.Services.FuncionarioDomainService>();
            services.AddScoped<Coti.Domain.Interface.Service.IUsuarioDomainService, Coti.Domain.Services.UsuarioDomainService>();

            #endregion

            #region Repository
            services.AddScoped<Coti.Domain.Interface.Repository.IDependenteRepository, Coti.Infrastructure.Data.DependenteRepository>();
            services.AddScoped<Coti.Domain.Interface.Repository.IFuncionarioRepository, Coti.Infrastructure.Data.FuncionarioRepository>();
            services.AddScoped<Coti.Domain.Interface.Repository.IUsuarioRepository, Coti.Infrastructure.Data.UsuarioRepository>();

            #endregion
        }
    }
}
