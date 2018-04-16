using System;
using System.Collections.Generic;
using System.Linq;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Infra.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoJogos.Infra.Data.SqlServer.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private readonly ContextEf _context;

        public JogoRepository(ContextEf context)
        {
            _context = context;
        }


        public void Adicionar(Jogo jogo)
        {
            _context.Jogos.Add(jogo);
            _context.SaveChanges();
        }

        public void Atualizar(Jogo jogo)
        {
            _context.Entry(jogo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Jogo Obter(int jogoId)
        {
            return _context.Jogos.AsNoTracking().FirstOrDefault(j => j.JogoId == jogoId);
        }

        public List<Jogo> ObterTodos(int usuarioId)
        {
            return _context.Jogos.Where(j => j.UsuarioId == usuarioId && !j.Excluido).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}