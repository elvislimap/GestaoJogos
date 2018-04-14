using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Interfaces
{
    public interface IPessoaAppService
    {
        Result Adicionar(Pessoa pessoa);
        Result Atualizar(Pessoa pessoa);
        Result Obter(int pessoaId);
        Result ObterTodos(int usuarioId);
    }
}