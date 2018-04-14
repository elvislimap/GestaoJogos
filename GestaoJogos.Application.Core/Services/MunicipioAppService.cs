using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Services
{
    public class MunicipioAppService : IMunicipioAppService
    {
        private readonly IMunicipioRepository _municipioRepository;

        public MunicipioAppService(IMunicipioRepository municipioRepository)
        {
            _municipioRepository = municipioRepository;
        }


        public Result Obter(int estadoId)
        {
            throw new System.NotImplementedException();
        }
    }
}