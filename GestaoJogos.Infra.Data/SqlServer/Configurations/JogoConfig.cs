using GestaoJogos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoJogos.Infra.Data.SqlServer.Configurations
{
    public class JogoConfig : IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.HasKey(c => c.JogoId);
            builder.Property(c => c.JogoId).UseSqlServerIdentityColumn();
            builder.Property(c => c.JogoId).ValueGeneratedOnAdd();
        }
    }
}