using System;
using System.Collections.Generic;
using GestaoJogos.Domain.Entities;

namespace GestaoJogos.Domain.Interfaces.Repositories
{
    public interface IFabricanteRepository : IDisposable
    {
        void Adicionar(Fabricante fabricante);
        void Atualizar(Fabricante fabricante);
        Fabricante Obter(int fabricanteId);
        List<Fabricante> ObterTodos(int usuarioId);
    }
}