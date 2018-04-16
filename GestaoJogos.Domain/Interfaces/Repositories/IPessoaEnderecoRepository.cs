using System;
using GestaoJogos.Domain.Entities;

namespace GestaoJogos.Domain.Interfaces.Repositories
{
    public interface IPessoaEnderecoRepository : IDisposable
    {
        void Adicionar(PessoaEndereco pessoaEndereco);
        void Atualizar(PessoaEndereco pessoaEndereco);
        PessoaEndereco Obter(int pessoaEnderecoId);
        PessoaEndereco ObterPorPessoa(int pessoaId);
    }
}