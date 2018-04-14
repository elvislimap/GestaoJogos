using System;
using System.Collections.Generic;
using System.Linq;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Infra.Data.SqlServer.Context;

namespace GestaoJogos.Infra.Data.SqlServer.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ContextEf _context;

        public EnderecoRepository(ContextEf context)
        {
            _context = context;
        }


        public void Adicionar(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
        }

        public List<Endereco> ObterTodos()
        {
            return _context.Enderecos.ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}