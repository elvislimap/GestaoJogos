using GestaoJogos.Domain.Commons;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.Interfaces.Services;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepository _jogoRepository;

        public JogoService(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }


        public Result Atualizar(Jogo jogo)
        {
            var jogoBd = _jogoRepository.Obter(jogo.JogoId);

            if (jogoBd == null)
                return new Result {Messages = "Jogo não encontrado".StringToList()};

            jogoBd.Nome = jogo.Nome;
            jogoBd.Excluido = jogo.Excluido;

            _jogoRepository.Atualizar(jogo);

            return new Result();
        }
    }
}