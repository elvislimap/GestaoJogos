using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Services
{
    public class JogoAppService : IJogoAppService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoAppService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }


        public Result Adicionar(Jogo jogo)
        {
            throw new System.NotImplementedException();
        }

        public Result Atualizar(Jogo jogo)
        {
            throw new System.NotImplementedException();
        }

        public Result Obter(int jogoId)
        {
            throw new System.NotImplementedException();
        }

        public Result Obter(int usuarioId, string filtro)
        {
            throw new System.NotImplementedException();
        }

        public Result ObterTodos(int usuarioId)
        {
            throw new System.NotImplementedException();
        }
    }
}