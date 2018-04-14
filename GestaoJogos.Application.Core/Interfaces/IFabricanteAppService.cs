using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Interfaces
{
    public interface IFabricanteAppService
    {
        Result Adicionar(Fabricante fabricante);
        Result Atualizar(Fabricante fabricante);
        Result ObterTodos(int usuarioId);
    }
}