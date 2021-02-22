using Coti.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Domain.Interface.Service
{
    public interface IUsuarioDomainService : IBaseDomainService<Usuario>
    {
        Usuario Get(string email, string senha);
    }
}
