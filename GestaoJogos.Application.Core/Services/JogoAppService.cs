using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.Interfaces.Services;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Services
{
    public class JogoAppService : IJogoAppService
    {
        private readonly IJogoRepository _jogoRepository;
        private readonly IJogoService _jogoService;

        public JogoAppService(IJogoRepository jogoRepository, IJogoService jogoService)
        {
            _jogoRepository = jogoRepository;
            _jogoService = jogoService;
        }


        public Result Adicionar(Jogo jogo)
        {
            if (!jogo.IsValid(out var listValidationErrors))
                return new Result {ValidationErrors = listValidationErrors};

            _jogoRepository.Adicionar(jogo);

            return new Result();
        }

        public Result Atualizar(Jogo jogo)
        {
            return !jogo.IsValid(out var listValidationErrors)
                ? new Result {ValidationErrors = listValidationErrors}
                : _jogoService.Atualizar(jogo);
        }

        public Result Obter(int jogoId)
        {
            return new Result {Return = _jogoRepository.Obter(jogoId)};
        }

        public Result Obter(int usuarioId, string filtro)
        {
            return new Result {Return = _jogoRepository.Obter(usuarioId, filtro)};
        }

        public Result ObterTodos(int usuarioId)
        {
            return new Result {Return = _jogoRepository.ObterTodos(usuarioId)};
        }
    }
}