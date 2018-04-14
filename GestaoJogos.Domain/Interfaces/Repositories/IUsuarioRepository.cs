using System;
using System.Collections.Generic;
using GestaoJogos.Domain.Entities;

namespace GestaoJogos.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IDisposable
    {
        void Adicionar(Usuario usuario);
        Usuario Obter(string email, string senha);
        List<Usuario> Obter(string email);
    }
}