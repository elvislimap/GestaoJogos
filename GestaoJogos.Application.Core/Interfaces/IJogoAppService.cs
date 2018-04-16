using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Interfaces
{
    public interface IJogoAppService
    {
        Result Adicionar(Jogo jogo);
        Result Atualizar(Jogo jogo);
        Result Obter(int jogoId);
        Result ObterTodos(int usuarioId);
    }
}