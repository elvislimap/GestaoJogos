using System;
using System.Collections.Generic;
using GestaoJogos.Domain.Entities;

namespace GestaoJogos.Domain.Interfaces.Repositories
{
    public interface IDevolucaoRepository : IDisposable
    {
        void Adicionar(Devolucao devolucao);
        List<Devolucao> ObterTodos(int usuarioId);
    }
}