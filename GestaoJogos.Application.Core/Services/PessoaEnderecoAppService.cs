using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.Interfaces.Services;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Services
{
    public class PessoaEnderecoAppService : IPessoaEnderecoAppService
    {
        private readonly IPessoaEnderecoRepository _pessoaEnderecoRepository;
        private readonly IPessoaEnderecoService _pessoaEnderecoService;

        public PessoaEnderecoAppService(IPessoaEnderecoRepository pessoaEnderecoRepository,
            IPessoaEnderecoService pessoaEnderecoService)
        {
            _pessoaEnderecoRepository = pessoaEnderecoRepository;
            _pessoaEnderecoService = pessoaEnderecoService;
        }


        public Result Adicionar(PessoaEndereco pessoaEndereco)
        {
            _pessoaEnderecoRepository.Adicionar(pessoaEndereco);
            return new Result();
        }

        public Result Atualizar(PessoaEndereco pessoaEndereco)
        {
            return _pessoaEnderecoService.Atualizar(pessoaEndereco);
        }

        public Result Obter(int pessoaEnderecoId)
        {
            return new Result {Return = _pessoaEnderecoRepository.Obter(pessoaEnderecoId)};
        }

        public Result ObterPorPessoa(int pessoaId)
        {
            return new Result {Return = _pessoaEnderecoRepository.ObterPorPessoa(pessoaId)};
        }
    }
}