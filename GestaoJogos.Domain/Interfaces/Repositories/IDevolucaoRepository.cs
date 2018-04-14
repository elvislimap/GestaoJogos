using System;
using GestaoJogos.Domain.Entities;

namespace GestaoJogos.Domain.Interfaces.Repositories
{
    public interface IDevolucaoRepository : IDisposable
    {
        void Adicionar(Devolucao devolucao);
    }
}