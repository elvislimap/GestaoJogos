using System;
using System.Collections.Generic;
using System.Linq;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Infra.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

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
            var listaEmprestimosIdsDevolvidos = _context.Devolucoes.Where(d => d.UsuarioId == usuarioId)
                .Select(d => d.EmprestimoId).ToList();

            return _context.Emprestimos.Include(e => e.Pessoa).Include(e => e.Jogo).Where(e =>
                e.UsuarioId == usuarioId && !listaEmprestimosIdsDevolvidos.Contains(e.EmprestimoId)).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}