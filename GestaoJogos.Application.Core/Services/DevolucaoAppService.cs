using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Services
{
    public class DevolucaoAppService : IDevolucaoAppService
    {
        private readonly IDevolucaoRepository _devolucaoRepository;

        public DevolucaoAppService(IDevolucaoRepository devolucaoRepository)
        {
            _devolucaoRepository = devolucaoRepository;
        }


        public Result Adicionar(Devolucao devolucao)
        {
            throw new System.NotImplementedException();
        }
    }
}