using Coti.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Application.Interface
{
    public interface IDependenteApplicationService
    {
        List<DependenteFormDTO> ListarDepedentePorFuncionario(int idFuncionario);
    }
}
