using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Services
{
    public class FabricanteAppService : IFabricanteAppService
    {
        private readonly IFabricanteRepository _fabricanteRepository;

        public FabricanteAppService(IFabricanteRepository fabricanteRepository)
        {
            _fabricanteRepository = fabricanteRepository;
        }


        public Result Adicionar(Fabricante fabricante)
        {
            throw new System.NotImplementedException();
        }

        public Result Atualizar(Fabricante fabricante)
        {
            throw new System.NotImplementedException();
        }

        public Result ObterTodos(int usuarioId)
        {
            throw new System.NotImplementedException();
        }
    }
}