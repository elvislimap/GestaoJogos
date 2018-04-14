using System;
using System.Collections.Generic;
using GestaoJogos.Domain.Entities;

namespace GestaoJogos.Domain.Interfaces.Repositories
{
    public interface IEmprestimoRepository : IDisposable
    {
        void Adicionar(Emprestimo emprestimo);
        Emprestimo Obter(int emprestimoId);
        List<Emprestimo> ObterTodos(int usuarioId);
    }
}