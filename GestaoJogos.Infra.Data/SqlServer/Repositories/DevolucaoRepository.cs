using System;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Infra.Data.SqlServer.Context;

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

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}