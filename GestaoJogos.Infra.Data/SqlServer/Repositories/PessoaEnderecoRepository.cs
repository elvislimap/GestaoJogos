using System;
using System.Linq;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Infra.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoJogos.Infra.Data.SqlServer.Repositories
{
    public class PessoaEnderecoRepository : IPessoaEnderecoRepository
    {
        private readonly ContextEf _context;

        public PessoaEnderecoRepository(ContextEf context)
        {
            _context = context;
        }


        public void Adicionar(PessoaEndereco pessoaEndereco)
        {
            _context.PessoaEnderecos.Add(pessoaEndereco);
            _context.SaveChanges();
        }

        public void Atualizar(PessoaEndereco pessoaEndereco)
        {
            _context.Entry(pessoaEndereco).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public PessoaEndereco Obter(int pessoaEnderecoId)
        {
            return _context.PessoaEnderecos.AsNoTracking().FirstOrDefault(p => p.PessoaEnderecoId == pessoaEnderecoId);
        }

        public PessoaEndereco ObterPorPessoa(int pessoaId)
        {
            return _context.PessoaEnderecos.Include(p => p.Pessoa).Include(p => p.Endereco)
                .FirstOrDefault(p => p.PessoaId == pessoaId && !p.Excluido && !p.Pessoa.Excluido);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}