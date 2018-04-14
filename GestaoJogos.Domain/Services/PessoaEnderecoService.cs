using GestaoJogos.Domain.Commons;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.Interfaces.Services;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Services
{
    public class PessoaEnderecoService : IPessoaEnderecoService
    {
        private readonly IPessoaEnderecoRepository _pessoaEnderecoRepository;

        public PessoaEnderecoService(IPessoaEnderecoRepository pessoaEnderecoRepository)
        {
            _pessoaEnderecoRepository = pessoaEnderecoRepository;
        }


        public Result Atualizar(PessoaEndereco pessoaEndereco)
        {
            var pessoaEnderecoBd = _pessoaEnderecoRepository.Obter(pessoaEndereco.PessoaEnderecoId);

            if (pessoaEnderecoBd == null)
                return new Result {Messages = "Endereco não encontrado".StringToList()};

            pessoaEnderecoBd.Excluido = pessoaEndereco.Excluido;

            _pessoaEnderecoRepository.Atualizar(pessoaEndereco);

            return new Result();
        }
    }
}