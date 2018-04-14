using System;
using System.Collections.Generic;
using System.Linq;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Infra.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoJogos.Infra.Data.SqlServer.Repositories
{
    public class FabricanteRepository : IFabricanteRepository
    {
        private readonly ContextEf _context;

        public FabricanteRepository(ContextEf context)
        {
            _context = context;
        }


        public void Adicionar(Fabricante fabricante)
        {
            _context.Fabricantes.Add(fabricante);
            _context.SaveChanges();
        }

        public void Atualizar(Fabricante fabricante)
        {
            _context.Entry(fabricante).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<Fabricante> ObterTodos(int usuarioId)
        {
            return _context.Fabricantes.Where(f => f.UsuarioId == usuarioId).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}