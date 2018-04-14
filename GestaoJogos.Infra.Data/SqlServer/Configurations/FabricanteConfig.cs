using GestaoJogos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoJogos.Infra.Data.SqlServer.Configurations
{
    public class FabricanteConfig : IEntityTypeConfiguration<Fabricante>
    {
        public void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            builder.HasKey(c => c.FabricanteId);
            builder.Property(c => c.FabricanteId).UseSqlServerIdentityColumn();
            builder.Property(c => c.FabricanteId).ValueGeneratedOnAdd();
        }
    }
}