using GestaoJogos.Domain.Entities;
using GestaoJogos.Infra.Data.SqlServer.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GestaoJogos.Infra.Data.SqlServer.Context
{
    public sealed class ContextEf : DbContext
    {
        public DbSet<Devolucao> Devolucoes { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaEndereco> PessoaEnderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public ContextEf(DbContextOptions options) : base(options)
        {
            Database.SetCommandTimeout(1800000);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.RemovePluralizingTableNameConvention();

            #region Configurations

            modelBuilder.ApplyConfiguration(new DevolucaoConfig());
            modelBuilder.ApplyConfiguration(new EmprestimoConfig());
            modelBuilder.ApplyConfiguration(new EnderecoConfig());
            modelBuilder.ApplyConfiguration(new JogoConfig());
            modelBuilder.ApplyConfiguration(new PessoaConfig());
            modelBuilder.ApplyConfiguration(new PessoaEnderecoConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());

            #endregion
        }
    }
}