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
            if (!emprestimo.IsValid(out var listValidationErrors))
                return new Result {ValidationErrors = listValidationErrors};

            _emprestimoRepository.Adicionar(emprestimo);

            return new Result();
        }

        public Result Obter(int emprestimoId)
        {
            return new Result {Return = _emprestimoRepository.Obter(emprestimoId)};
        }

        public Result ObterTodos(int usuarioId)
        {
            return new Result {Return = _emprestimoRepository.ObterTodos(usuarioId)};
        }
    }
}