using AutoMapper;
using Coti.Application.DTO;
using Coti.Application.Model;
using Coti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Application.AutoMapper
{
    public class ModelToDomainMappingProfile : Profile
    {
        public ModelToDomainMappingProfile()
        {
            #region Usuario
            CreateMap<UsuarioFormModel, Usuario>()
                .AfterMap((src, dest) => 
                {
                    dest.IdUsuario = Guid.NewGuid();
                    dest.DataHoraCadastro = DateTime.Now;
                });
            
            

            #endregion

            #region Funcionario
            CreateMap<FuncionarioFormModel, Funcionario>();
            CreateMap<FuncionarioEditModel, Funcionario>();

            #endregion

            #region Dependente
            CreateMap<DependenteFormModel, Dependente>();
            CreateMap<DependenteEditModel, Dependente>();

            #endregion
        }
    }
}
