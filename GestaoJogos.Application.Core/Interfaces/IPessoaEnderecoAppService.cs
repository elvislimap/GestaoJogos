using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Interfaces
{
    public interface IPessoaEnderecoAppService
    {
        Result Adicionar(PessoaEndereco pessoaEndereco);
        Result Atualizar(PessoaEndereco pessoaEndereco);
        Result Obter(int pessoaEnderecoId);
        Result ObterPorPessoa(int pessoaId);
    }
}