using GestaoJogos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoJogos.Infra.Data.SqlServer.Configurations
{
    public class DevolucaoConfig : IEntityTypeConfiguration<Devolucao>
    {
        public void Configure(EntityTypeBuilder<Devolucao> builder)
        {
            builder.HasKey(c => c.DevolucaoId);
            builder.Property(c => c.DevolucaoId).UseSqlServerIdentityColumn();
            builder.Property(c => c.DevolucaoId).ValueGeneratedOnAdd();
        }
    }
}