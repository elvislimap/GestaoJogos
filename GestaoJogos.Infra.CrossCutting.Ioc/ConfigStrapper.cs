using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Application.Core.Services;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.Interfaces.Services;
using GestaoJogos.Domain.Services;
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

            #region AppServices

            services.AddScoped<ICategoriaAppService, CategoriaAppService>();
            services.AddScoped<IDevolucaoAppService, DevolucaoAppService>();
            services.AddScoped<IEmprestimoAppService, EmprestimoAppService>();
            services.AddScoped<IEnderecoAppService, EnderecoAppService>();
            services.AddScoped<IFabricanteAppService, FabricanteAppService>();
            services.AddScoped<IJogoAppService, JogoAppService>();
            services.AddScoped<IMunicipioAppService, MunicipioAppService>();
            services.AddScoped<IPessoaEnderecoAppService, PessoaEnderecoAppService>();
            services.AddScoped<IPessoaAppService, PessoaAppService>();
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();

            #endregion

            #region Services

            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IFabricanteService, FabricanteService>();
            services.AddScoped<IJogoService, JogoService>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IPessoaEnderecoService, PessoaEnderecoService>();

            #endregion

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