using System;
using System.Collections.Generic;
using System.Linq;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Infra.Data.SqlServer.Context;

namespace GestaoJogos.Infra.Data.SqlServer.Repositories
{
    public class MunicipioRepository : IMunicipioRepository
    {
        private readonly ContextEf _context;

        public MunicipioRepository(ContextEf context)
        {
            _context = context;
        }


        public List<Municipio> Obter(int estadoId)
        {
            return _context.Municipios.Where(m => m.EstadoId == estadoId).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}