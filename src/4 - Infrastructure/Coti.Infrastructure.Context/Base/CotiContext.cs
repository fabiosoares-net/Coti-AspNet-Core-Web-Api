using Microsoft.EntityFrameworkCore;
using Coti.Domain.Entities;
// using Projeto01.Infra.Data.SqlServer.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Infrastructure.Context.Base
{
    public class CotiContext : DbContext
    {
        public CotiContext(DbContextOptions<CotiContext> options) : base(options) { }

        #region Properties
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Dependente> Dependente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CotiContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
