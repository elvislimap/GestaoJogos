using System;
using System.Collections.Generic;
using System.Linq;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Infra.Data.SqlServer.Context;

namespace GestaoJogos.Infra.Data.SqlServer.Repositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly ContextEf _context;

        public EmprestimoRepository(ContextEf context)
        {
            _context = context;
        }


        public void Adicionar(Emprestimo emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
            _context.SaveChanges();
        }

        public Emprestimo Obter(int emprestimoId)
        {
            return _context.Emprestimos.Find(emprestimoId);
        }

        public List<Emprestimo> ObterTodos(int usuarioId)
        {
            return _context.Emprestimos.Where(u => u.UsuarioId == usuarioId).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}