using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Infra.Data.SqlServer.Context;
using GestaoJogos.Infra.Data.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace GestaoJogos.Infra.CrossCutting.Ioc
{
    public class ConfigStrapper
    {
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {
            services.AddCors();
            services.AddDbContext<ContextEf>(opt => opt.UseSqlServer(connectionString));
            services.AddMvc().AddJsonOptions(opt =>
                opt.SerializerSettings.ContractResolver = new DefaultContractResolver());

            #region Repositories

            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IDevolucaoRepository, DevolucaoRepository>();
            services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IFabricanteRepository, FabricanteRepository>();
            services.AddScoped<IJogoRepository, JogoRepository>();
            services.AddScoped<IMunicipioRepository, MunicipioRepository>();
            services.AddScoped<IPessoaEnderecoRepository, PessoaEnderecoRepository>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            #endregion
        }
    }
}