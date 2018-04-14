using System;
using GestaoJogos.Domain.Entities;

namespace GestaoJogos.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IDisposable
    {
        void Adicionar(Usuario usuario);
        void Atualizar(Usuario usuario);
        Usuario Obter(string email, string senha);
    }
}