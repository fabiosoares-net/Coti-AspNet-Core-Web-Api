using Coti.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Coti.Infrastructure.Context.Mapping
{
    public class FuncionarioMapping : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");

            builder.HasKey(t => t.IdFuncionario);
            builder.Property(t => t.IdFuncionario).HasColumnName("IdFuncionario");
            builder.Property(t => t.Nome).HasColumnName("Nome").HasMaxLength(150).IsRequired();
            builder.Property(t => t.CPF).HasColumnName("CPF").HasMaxLength(30).IsRequired();
            builder.Property(t => t.DataAdmissao).HasColumnName("DataAdmissao").HasColumnType("date").IsRequired();
        }
    }
}
