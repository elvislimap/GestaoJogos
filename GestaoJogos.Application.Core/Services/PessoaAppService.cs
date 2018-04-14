using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.Interfaces.Services;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Services
{
    public class PessoaAppService : IPessoaAppService
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaService _pessoaService;

        public PessoaAppService(IPessoaRepository pessoaRepository, IPessoaService pessoaService)
        {
            _pessoaRepository = pessoaRepository;
            _pessoaService = pessoaService;
        }


        public Result Adicionar(Pessoa pessoa)
        {
            if (!pessoa.IsValid(out var listValidationErrors))
                return new Result {ValidationErrors = listValidationErrors};

            _pessoaRepository.Adicionar(pessoa);

            return new Result();
        }

        public Result Atualizar(Pessoa pessoa)
        {
            return !pessoa.IsValid(out var listValidationErrors)
                ? new Result {ValidationErrors = listValidationErrors}
                : _pessoaService.Atualizar(pessoa);
        }

        public Result Obter(int pessoaId)
        {
            return new Result {Return = _pessoaRepository.Obter(pessoaId)};
        }

        public Result ObterTodos(int usuarioId)
        {
            return new Result {Return = _pessoaRepository.ObterTodos(usuarioId)};
        }
    }
}