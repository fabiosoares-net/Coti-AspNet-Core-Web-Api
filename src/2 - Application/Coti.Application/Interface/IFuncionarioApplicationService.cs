using Coti.Application.DTO;
using Coti.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Application.Interface
{
    public interface IFuncionarioApplicationService : IDisposable
    {
        FuncionarioFormDTO Post(CriacaoFuncionarioFormModel itm);
        void Put(EdicaoFuncionarioFormModel itm);
        void Delete(int id);
        List<FuncionarioGridDTO> Query(FuncionarioFilter filter);
        FuncionarioFormDTO Get(int id);
    }
}
