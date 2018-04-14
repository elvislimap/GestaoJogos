using System;
using System.Collections.Generic;
using GestaoJogos.Domain.Entities;

namespace GestaoJogos.Domain.Interfaces.Repositories
{
    public interface IMunicipioRepository : IDisposable
    {
        List<Municipio> Obter(int estadoId);
    }
}