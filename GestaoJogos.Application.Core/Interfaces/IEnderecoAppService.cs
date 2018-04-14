using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Interfaces
{
    public interface IEnderecoAppService
    {
        Result Adicionar(Endereco endereco);
        Result ObterTodos();
    }
}