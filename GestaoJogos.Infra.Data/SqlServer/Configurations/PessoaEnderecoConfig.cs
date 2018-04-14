using GestaoJogos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoJogos.Infra.Data.SqlServer.Configurations
{
    public class PessoaEnderecoConfig : IEntityTypeConfiguration<PessoaEndereco>
    {
        public void Configure(EntityTypeBuilder<PessoaEndereco> builder)
        {
            builder.HasKey(c => c.PessoaEnderecoId);
            builder.Property(c => c.PessoaEnderecoId).UseSqlServerIdentityColumn();
            builder.Property(c => c.PessoaEnderecoId).ValueGeneratedOnAdd();
        }
    }
}