using System;
using System.Collections.Generic;
using GestaoJogos.Domain.Entities;

namespace GestaoJogos.Domain.Interfaces.Repositories
{
    public interface ICategoriaRepository : IDisposable
    {
        void Adicionar(Categoria categoria);
        void Atualizar(Categoria categoria);
        Categoria Obter(int categoriaId);
        List<Categoria> ObterTodos(int usuarioId);
    }
}