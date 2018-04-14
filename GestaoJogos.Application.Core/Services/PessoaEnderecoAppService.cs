using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Services
{
    public class PessoaEnderecoAppService : IPessoaEnderecoAppService
    {
        private readonly IPessoaEnderecoRepository _pessoaEnderecoRepository;

        public PessoaEnderecoAppService(IPessoaEnderecoRepository pessoaEnderecoRepository)
        {
            _pessoaEnderecoRepository = pessoaEnderecoRepository;
        }


        public Result Adicionar(PessoaEndereco pessoaEndereco)
        {
            throw new System.NotImplementedException();
        }

        public Result Atualizar(PessoaEndereco pessoaEndereco)
        {
            throw new System.NotImplementedException();
        }

        public Result Obter(int pessoaEnderecoId)
        {
            throw new System.NotImplementedException();
        }

        public Result ObterPorPessoa(int pessoaId)
        {
            throw new System.NotImplementedException();
        }
    }
}