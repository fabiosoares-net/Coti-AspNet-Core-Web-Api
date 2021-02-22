using Coti.Domain.Entities;
using Coti.Domain.Interface.Repository;
using Coti.Infrastructure.Context.Base;
using Coti.Infrastructure.Context.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coti.Infrastructure.Data
{
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(CotiContext cotiContext) : base(cotiContext) { }

        public Funcionario ObterFuncionarioDependente(int idFuncionario)
        {
            return EntitySet
                .AsNoTracking()
                .Include(x => x.Dependente)
                .Where(x => x.IdFuncionario == idFuncionario)
                .FirstOrDefault();
        }
    }
}
