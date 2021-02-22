using Coti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Domain.Interface.Service
{
    public interface IFuncionarioDomainService : IBaseDomainService<Funcionario>
    {
        Funcionario ObterFuncionarioDependente(int idFuncionario);
    }
}
