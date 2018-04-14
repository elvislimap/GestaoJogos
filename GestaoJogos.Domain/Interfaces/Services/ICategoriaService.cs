using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Interfaces.Services
{
    public interface ICategoriaService
    {
        Result Atualizar(Categoria categoria);
    }
}