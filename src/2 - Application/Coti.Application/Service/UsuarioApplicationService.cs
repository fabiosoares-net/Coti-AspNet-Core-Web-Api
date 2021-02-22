using AutoMapper;
using Coti.Application.DTO;
using Coti.Application.Interface;
using Coti.Application.Model;
using Coti.Domain.Entities;
using Coti.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Application.Service
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IMapper mapper;
        private readonly IUsuarioDomainService usuarioDomainService;
        public UsuarioApplicationService(IMapper mapper, IUsuarioDomainService usuarioDomainService)
        {
            this.mapper = mapper;
            this.usuarioDomainService = usuarioDomainService;
        }

        public UsuarioDTO GetAccess(UsuarioAcessoModel itm)
        {
            var usuario = usuarioDomainService.Get(itm.Email, itm.Senha);

            if (usuario == null)
                return null;

            return mapper.Map<UsuarioDTO>(usuario);
        }

        public UsuarioDTO Post(UsuarioFormModel itm)
        {
            return mapper.Map<UsuarioDTO>(usuarioDomainService.Post(mapper.Map<Usuario>(itm)));
        }

        public void Dispose()
        {
            usuarioDomainService.Dispose();
        }
    }
}
