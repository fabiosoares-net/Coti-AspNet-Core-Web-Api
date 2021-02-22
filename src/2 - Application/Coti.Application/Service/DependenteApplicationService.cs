using AutoMapper;
using Coti.Application.DTO;
using Coti.Application.Interface;
using Coti.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coti.Application.Service
{
    public class DependenteApplicationService : IDependenteApplicationService
    {
        private readonly IMapper mapper;
        private readonly IDependenteDomainService dependenteDomainService;

        public DependenteApplicationService(
            IMapper mapper,
            IDependenteDomainService dependenteDomainService)
        {
            this.mapper = mapper;
            this.dependenteDomainService = dependenteDomainService;
        }

        public List<DependenteFormDTO> ListarDepedentePorFuncionario(int idFuncionario)
        {
            return mapper.Map<List<DependenteFormDTO>>(dependenteDomainService.Query(x => x.IdFuncionario == idFuncionario).ToList());
        }
    }
}
