using System;
using System.Collections.Generic;
using GestaoJogos.Domain.Entities;

namespace GestaoJogos.Domain.Interfaces.Repositories
{
    public interface IEnderecoRepository : IDisposable
    {
        void Adicionar(Endereco endereco);
        List<Endereco> ObterTodos();
    }
}