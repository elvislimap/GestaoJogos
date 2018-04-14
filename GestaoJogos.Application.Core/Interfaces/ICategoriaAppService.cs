using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Interfaces
{
    public interface ICategoriaAppService
    {
        Result Adicionar(Categoria categoria);
        Result Atualizar(Categoria categoria);
        Result ObterTodos(int usuarioId);
    }
}