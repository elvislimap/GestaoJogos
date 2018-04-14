using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Interfaces
{
    public interface IEmprestimoAppService
    {
        Result Adicionar(Emprestimo emprestimo);
        Result Obter(int emprestimoId);
        Result ObterTodos(int usuarioId);
    }
}