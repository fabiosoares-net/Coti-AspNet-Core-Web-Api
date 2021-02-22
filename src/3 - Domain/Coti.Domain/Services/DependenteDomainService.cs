using Coti.Domain.Entities;
using Coti.Domain.Interface.Repository;
using Coti.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Domain.Services
{
    public class DependenteDomainService : BaseDomainService<Dependente>, IDependenteDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public DependenteDomainService(IUnitOfWork unitOfWork) 
            : base(unitOfWork.DependenteRepository)
        {
        }
    }
}
