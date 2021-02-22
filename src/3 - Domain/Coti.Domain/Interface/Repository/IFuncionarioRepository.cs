using Coti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Domain.Interface.Repository
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        Funcionario ObterFuncionarioDependente(int idFuncionario);
    }
}
