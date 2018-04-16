using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Interfaces
{
    public interface IDevolucaoAppService
    {
        Result Adicionar(Devolucao devolucao);
        Result ObterTodos(int usuarioId);
    }
}