﻿using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Interfaces
{
    public interface IUsuarioAppService
    {
        Result Adicionar(Usuario usuario);
        Result Obter(string email, string senha);
    }
}