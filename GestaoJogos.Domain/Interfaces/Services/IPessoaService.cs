using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Interfaces.Services
{
    public interface IPessoaService
    {
        Result Atualizar(Pessoa pessoa);
    }
}