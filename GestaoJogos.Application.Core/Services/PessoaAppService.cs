using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Services
{
    public class PessoaAppService : IPessoaAppService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaAppService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }


        public Result Adicionar(Pessoa pessoa)
        {
            throw new System.NotImplementedException();
        }

        public Result Atualizar(Pessoa pessoa)
        {
            throw new System.NotImplementedException();
        }

        public Result Obter(int pessoaId)
        {
            throw new System.NotImplementedException();
        }

        public Result ObterTodos(int usuarioId)
        {
            throw new System.NotImplementedException();
        }
    }
}