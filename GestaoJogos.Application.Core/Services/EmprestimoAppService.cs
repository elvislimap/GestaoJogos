using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Services
{
    public class EmprestimoAppService : IEmprestimoAppService
    {
        private readonly IEmprestimoRepository _emprestimoRepository;

        public EmprestimoAppService(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }


        public Result Adicionar(Emprestimo emprestimo)
        {
            throw new System.NotImplementedException();
        }

        public Result Obter(int emprestimoId)
        {
            throw new System.NotImplementedException();
        }

        public Result ObterTodos(int usuarioId)
        {
            throw new System.NotImplementedException();
        }
    }
}