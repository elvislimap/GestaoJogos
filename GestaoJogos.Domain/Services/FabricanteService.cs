using GestaoJogos.Domain.Commons;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.Interfaces.Services;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Services
{
    public class FabricanteService : IFabricanteService
    {
        private readonly IFabricanteRepository _fabricanteRepository;

        public FabricanteService(IFabricanteRepository fabricanteRepository)
        {
            _fabricanteRepository = fabricanteRepository;
        }


        public Result Atualizar(Fabricante fabricante)
        {
            var fabricanteBd = _fabricanteRepository.Obter(fabricante.FabricanteId);

            if (fabricanteBd == null)
                return new Result {Messages = "Fabricante não encontrado".StringToList()};

            fabricanteBd.Nome = fabricante.Nome;
            fabricanteBd.Excluido = fabricante.Excluido;

            _fabricanteRepository.Atualizar(fabricanteBd);

            return new Result();
        }
    }
}