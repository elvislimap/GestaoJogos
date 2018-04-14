using GestaoJogos.Domain.Commons;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Repositories;
using GestaoJogos.Domain.Interfaces.Services;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }


        public Result Atualizar(Pessoa pessoa)
        {
            var pessoaBd = _pessoaRepository.Obter(pessoa.PessoaId);

            if (pessoaBd == null)
                return new Result {Messages = "Amigo não encontrado".StringToList()};

            pessoaBd.Nome = pessoa.Nome;
            pessoaBd.Sobrenome = pessoa.Sobrenome;
            pessoaBd.Cpf = pessoa.Cpf;
            pessoaBd.Telefone = pessoa.Telefone;
            pessoaBd.Email = pessoa.Email;
            pessoaBd.Excluido = pessoa.Excluido;

            _pessoaRepository.Atualizar(pessoaBd);

            return new Result();
        }
    }
}