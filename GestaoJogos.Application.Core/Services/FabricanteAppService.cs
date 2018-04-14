using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.Interfaces.Services;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Services
{
    public class FabricanteAppService : IFabricanteAppService
    {
        private readonly IFabricanteRepository _fabricanteRepository;
        private readonly IFabricanteService _fabricanteService;

        public FabricanteAppService(IFabricanteRepository fabricanteRepository, IFabricanteService fabricanteService)
        {
            _fabricanteRepository = fabricanteRepository;
            _fabricanteService = fabricanteService;
        }


        public Result Adicionar(Fabricante fabricante)
        {
            if (!fabricante.IsValid(out var listValidationErrors))
                return new Result {ValidationErrors = listValidationErrors};

            _fabricanteRepository.Adicionar(fabricante);

            return new Result();
        }

        public Result Atualizar(Fabricante fabricante)
        {
            return !fabricante.IsValid(out var listValidationErrors)
                ? new Result {ValidationErrors = listValidationErrors}
                : _fabricanteService.Atualizar(fabricante);
        }

        public Result ObterTodos(int usuarioId)
        {
            return new Result {Return = _fabricanteRepository.ObterTodos(usuarioId)};
        }
    }
}