using Coti.Domain.Entities;
using Coti.Domain.Interface.Repository;
using Coti.Infrastructure.Context.Base;
using Coti.Infrastructure.Context.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Infrastructure.Data
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(CotiContext cotiContext) : base(cotiContext) { }
    }
}
