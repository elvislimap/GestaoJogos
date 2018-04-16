using System;
using System.Collections.Generic;
using GestaoJogos.Domain.Entities;

namespace GestaoJogos.Domain.Interfaces.Repositories
{
    public interface IJogoRepository : IDisposable
    {
        void Adicionar(Jogo jogo);
        void Atualizar(Jogo jogo);
        Jogo Obter(int jogoId);
        List<Jogo> ObterTodos(int usuarioId);
    }
}