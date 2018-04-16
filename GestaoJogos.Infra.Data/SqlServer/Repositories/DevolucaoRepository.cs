using System;
using System.Collections.Generic;
using System.Linq;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Infra.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoJogos.Infra.Data.SqlServer.Repositories
{
    public class DevolucaoRepository : IDevolucaoRepository
    {
        private readonly ContextEf _context;

        public DevolucaoRepository(ContextEf context)
        {
            _context = context;
        }


        public void Adicionar(Devolucao devolucao)
        {
            _context.Devolucoes.Add(devolucao);
            _context.SaveChanges();
        }

        public List<Devolucao> ObterTodos(int usuarioId)
        {
            return _context.Devolucoes.Include(d => d.Emprestimo).ThenInclude(e => e.Pessoa).Include(d => d.Emprestimo)
                .ThenInclude(e => e.Jogo).Where(d => d.UsuarioId == usuarioId).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}