using GestaoJogos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoJogos.Infra.Data.SqlServer.Configurations
{
    public class EmprestimoConfig : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.HasKey(c => c.EmprestimoId);
            builder.Property(c => c.EmprestimoId).UseSqlServerIdentityColumn();
            builder.Property(c => c.EmprestimoId).ValueGeneratedOnAdd();
        }
    }
}