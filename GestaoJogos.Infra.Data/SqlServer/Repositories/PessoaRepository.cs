using System;
using System.Collections.Generic;
using System.Linq;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Infra.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoJogos.Infra.Data.SqlServer.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ContextEf _context;

        public PessoaRepository(ContextEf context)
        {
            _context = context;
        }


        public void Adicionar(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
        }

        public void Atualizar(Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Pessoa Obter(int pessoaId)
        {
            return _context.Pessoas.Find(pessoaId);
        }

        public List<Pessoa> ObterTodos(int usuarioId)
        {
            return _context.Pessoas.Where(p => p.UsuarioId == usuarioId && !p.Excluido).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}