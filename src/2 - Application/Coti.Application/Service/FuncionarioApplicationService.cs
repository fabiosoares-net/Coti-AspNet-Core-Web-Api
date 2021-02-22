using AutoMapper;
using Coti.Application.DTO;
using Coti.Application.Interface;
using Coti.Application.Model;
using Coti.Domain.Entities;
using Coti.Domain.Interface.Repository;
using Coti.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coti.Application.Service
{
    public class FuncionarioApplicationService : IFuncionarioApplicationService
    {
        private readonly IMapper mapper;
        private readonly IFuncionarioDomainService funcionarioDomainService; 

        public FuncionarioApplicationService(
            IMapper mapper,
            IFuncionarioDomainService funcionarioDomainService)
        {
            this.mapper = mapper;
            this.funcionarioDomainService = funcionarioDomainService;
        }

        public void Delete(int id)
        {
            var funcionario = funcionarioDomainService.Get(id);

            if (funcionario == null)
                throw new Exception("Funcionário não encontrado.");

            funcionarioDomainService.Delete(funcionario);
        }

        public FuncionarioFormDTO Get(int id)
        {
            return mapper.Map<FuncionarioFormDTO>(funcionarioDomainService.ObterFuncionarioDependente(id));
        }

        public FuncionarioFormDTO Post(CriacaoFuncionarioFormModel itm)
        {
            try
            {
                var funcionario = mapper.Map<Funcionario>(itm.Funcionario);
                funcionario.Dependente = mapper.Map<List<Dependente>>(itm.Dependente);

                var funcionarioBD = funcionarioDomainService.Post(funcionario);

                return mapper.Map<FuncionarioFormDTO>(funcionarioBD);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Put(EdicaoFuncionarioFormModel itm)
        {
            try
            {
                var funcionario = mapper.Map<Funcionario>(itm.Funcionario);
                funcionario.Dependente = mapper.Map<List<Dependente>>(itm.Dependente);

                funcionarioDomainService.Put(funcionario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<FuncionarioGridDTO> Query(FuncionarioFilter filter)
        {
            var lista = funcionarioDomainService
                .Query(x => !string.IsNullOrEmpty(filter.Nome) ? x.Nome.Trim().Contains(filter.Nome.Trim()) : true &&
                            !string.IsNullOrEmpty(filter.CPF) ? x.CPF.Trim().Contains(filter.CPF.Trim()) : true &&
                            filter.Tipo.HasValue ? x.TipoFuncionario.Equals(filter.Tipo) : true)
                .OrderBy(x => x.Nome)
                .ToList();

            return mapper.Map<List<FuncionarioGridDTO>>(lista);
        }

        public void Dispose()
        {
            funcionarioDomainService.Dispose();
        }
    }
}
