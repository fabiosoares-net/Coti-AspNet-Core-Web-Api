using Coti.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Coti.Infrastructure.Context.Mapping
{
    public class DependenteMapping : IEntityTypeConfiguration<Dependente>
    {
        public void Configure(EntityTypeBuilder<Dependente> builder)
        {
            builder.ToTable("Dependente");

            builder.HasKey(t => t.IdDependente);
            builder.Property(t => t.IdFuncionario).HasColumnName("IdFuncionario");
            builder.Property(t => t.Nome).HasColumnName("Nome").HasMaxLength(150).IsRequired();
            builder.Property(t => t.DataNascimento).HasColumnName("DataNascimento").HasColumnType("date").IsRequired();

            builder.HasOne(t => t.Funcionario) // Dependente TEM 1 Funcionario
                .WithMany(f => f.Dependente) // Funcionario TEM N Dependentes
                .HasForeignKey(t => t.IdFuncionario); // Chave estrangeira
        }
    }
}
