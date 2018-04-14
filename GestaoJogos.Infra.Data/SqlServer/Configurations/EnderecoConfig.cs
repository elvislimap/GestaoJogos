using GestaoJogos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoJogos.Infra.Data.SqlServer.Configurations
{
    public class EnderecoConfig : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(c => c.EnderecoId);
            builder.Property(c => c.EnderecoId).UseSqlServerIdentityColumn();
            builder.Property(c => c.EnderecoId).ValueGeneratedOnAdd();
        }
    }
}