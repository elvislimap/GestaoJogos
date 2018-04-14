using GestaoJogos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoJogos.Infra.Data.SqlServer.Configurations
{
    public class MunicipioConfig : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> builder)
        {
            builder.HasKey(c => c.MunicipioId);
            builder.Property(c => c.MunicipioId).UseSqlServerIdentityColumn();
            builder.Property(c => c.MunicipioId).ValueGeneratedOnAdd();
        }
    }
}