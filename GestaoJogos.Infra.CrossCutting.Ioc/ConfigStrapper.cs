using GestaoJogos.Infra.Data.SqlServer.Context;
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

            //services.AddScoped<Interface, Metodo>();
        }
    }
}