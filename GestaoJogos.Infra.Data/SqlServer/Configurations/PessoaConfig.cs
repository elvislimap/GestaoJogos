using GestaoJogos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoJogos.Infra.Data.SqlServer.Configurations
{
    public class PessoaConfig : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.HasKey(c => c.PessoaId);
            builder.Property(c => c.PessoaId).UseSqlServerIdentityColumn();
            builder.Property(c => c.PessoaId).ValueGeneratedOnAdd();
        }
    }
}