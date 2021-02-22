using Coti.Application.DTO;
using Coti.Application.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Application.Interface
{
    public interface IUsuarioApplicationService : IDisposable
    {
        UsuarioDTO Post(UsuarioFormModel itm);
        UsuarioDTO GetAccess(UsuarioAcessoModel itm);
    }
}
