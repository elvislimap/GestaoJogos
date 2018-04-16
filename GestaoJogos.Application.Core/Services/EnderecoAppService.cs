using GestaoJogos.Application.Core.Interfaces;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Application.Core.Services
{
    public class EnderecoAppService : IEnderecoAppService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoAppService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }


        public Result Adicionar(Endereco endereco)
        {
            if (!endereco.IsValid(out var listValidationErrors))
                return new Result {ValidationErrors = listValidationErrors};

            _enderecoRepository.Adicionar(endereco);

            return new Result {Return = endereco};
        }

        public Result ObterTodos()
        {
            return new Result {Return = _enderecoRepository.ObterTodos()};
        }
    }
}