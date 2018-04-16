using System;
using System.Collections.Generic;
using System.Linq;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.ValuesObjects;
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
            return _context.Pessoas.AsNoTracking().FirstOrDefault(p => p.PessoaId == pessoaId);
        }

        public AmigoAdd ObterComEndereco(int pessoaId)
        {
            var pessoa = _context.Pessoas.AsNoTracking().FirstOrDefault(p => p.PessoaId == pessoaId);
            var pessoaEndereco = _context.PessoaEnderecos.AsNoTracking().Include(p => p.Endereco)
                .LastOrDefault(p => p.PessoaId == pessoaId);

            return new AmigoAdd
            {
                Pessoa = pessoa,
                Endereco = pessoaEndereco == null ? new Endereco() : pessoaEndereco.Endereco
            };
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