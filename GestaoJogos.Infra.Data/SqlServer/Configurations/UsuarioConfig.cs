using GestaoJogos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoJogos.Infra.Data.SqlServer.Configurations
{
    public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(c => c.UsuarioId);
            builder.Property(c => c.UsuarioId).UseSqlServerIdentityColumn();
            builder.Property(c => c.UsuarioId).ValueGeneratedOnAdd();
        }
    }
}