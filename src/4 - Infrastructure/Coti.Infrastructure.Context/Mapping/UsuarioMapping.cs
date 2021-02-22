using Coti.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Coti.Infrastructure.Context.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(t => t.IdUsuario);

            builder.Property(t => t.IdUsuario).HasColumnName("IdUsuario");
            builder.Property(t => t.Nome).HasColumnName("Nome").HasMaxLength(150).IsRequired();
            builder.Property(t => t.Email).HasColumnName("Email").HasMaxLength(100).IsRequired();
            builder.Property(t => t.Senha).HasColumnName("Senha").HasMaxLength(50).IsRequired();
            builder.Property(t => t.DataHoraCadastro).HasColumnName("DataHoraCadastro").HasColumnType("datetime").IsRequired();
        }
    }
}
