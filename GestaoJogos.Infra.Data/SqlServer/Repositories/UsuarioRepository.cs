using System;
using System.Collections.Generic;
using System.Linq;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Infra.Data.SqlServer.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoJogos.Infra.Data.SqlServer.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ContextEf _context;

        public UsuarioRepository(ContextEf context)
        {
            _context = context;
        }


        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario Obter(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public List<Usuario> Obter(string email)
        {
            return _context.Usuarios.Where(u => u.Email == email).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}