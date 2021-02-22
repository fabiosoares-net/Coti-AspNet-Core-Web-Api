using Coti.Domain.Entities;
using Coti.Domain.Interface.Repository;
using Coti.Infrastructure.Context.Base;
using Coti.Infrastructure.Context.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Infrastructure.Data
{
    public class DependenteRepository : BaseRepository<Dependente>, IDependenteRepository
    {
        public DependenteRepository(CotiContext cotiContext) : base(cotiContext) { }
    }
}
