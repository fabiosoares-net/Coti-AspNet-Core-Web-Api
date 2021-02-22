using AutoMapper;
using Coti.Application.DTO;
using Coti.Domain.Entities;
using Coti.Domain.Extension;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Application.AutoMapper
{
    public class DomainToModelMappingProfile : Profile
    {
        public DomainToModelMappingProfile()
        {
            //CreateMap<Funcionario, FuncionarioDTO>()
            //    .AfterMap((src, dest) => 
            //    {
            //        dest.TipoFuncionario = src.TipoFuncionario.GetDescription();
            //        dest.DataAdmissao = src.DataAdmissao.ToString("d");
            //    });

            CreateMap<Funcionario, FuncionarioGridDTO>()
                .AfterMap((src, dest) =>
                {
                    dest.TipoFuncionario = src.TipoFuncionario.GetDescription();
                    dest.DataAdmissao = src.DataAdmissao.ToString("d");
                });

            CreateMap<Usuario, UsuarioDTO>()
                .AfterMap((src, dest) => 
                {
                    dest.DataHoraCadastro = src.DataHoraCadastro.ToString("d");
                });

            CreateMap<Funcionario, FuncionarioFormDTO>()
                .AfterMap((src, dest) =>
                {
                    dest.DataAdmissao = src.DataAdmissao.ToString("d");
                });

            CreateMap<Dependente, DependenteFormDTO>()
                .AfterMap((src, dest) =>
                {
                    dest.DataNascimento = src.DataNascimento.ToString("d");
                });
        }
    }
}
