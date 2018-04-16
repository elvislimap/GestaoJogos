using System;
using System.Collections.Generic;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository : IDisposable
    {
        void Adicionar(Pessoa pessoa);
        void Atualizar(Pessoa pessoa);
        Pessoa Obter(int pessoaId);
        AmigoAdd ObterComEndereco(int pessoaId);
        List<Pessoa> ObterTodos(int usuarioId);
    }
}