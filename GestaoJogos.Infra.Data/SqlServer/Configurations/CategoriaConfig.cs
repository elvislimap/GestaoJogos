using GestaoJogos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoJogos.Infra.Data.SqlServer.Configurations
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.CategoriaId);
            builder.Property(c => c.CategoriaId).UseSqlServerIdentityColumn();
            builder.Property(c => c.CategoriaId).ValueGeneratedOnAdd();
        }
    }
}