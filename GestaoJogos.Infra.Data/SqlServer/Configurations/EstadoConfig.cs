using GestaoJogos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoJogos.Infra.Data.SqlServer.Configurations
{
    public class EstadoConfig : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder.HasKey(c => c.EstadoId);
            builder.Property(c => c.EstadoId).UseSqlServerIdentityColumn();
            builder.Property(c => c.EstadoId).ValueGeneratedOnAdd();
        }
    }
}