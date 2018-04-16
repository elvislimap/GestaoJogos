using System.Linq;
using GestaoJogos.Domain.Entities;
using Xunit;

namespace GestaoJogos.Domain.UnitTest
{
    public class PessoaValidationUnitTest
    {
        [Fact]
        public void UsuarioIsValid()
        {
            var pessoa = new Pessoa()
            {
                Nome = "Elvis Augusto",
                Sobrenome = "Lima",
                Email = "elvislima_@hotmail.com"
            };

            Assert.True(pessoa.IsValid(out var listValidationErrors));
            Assert.False(listValidationErrors.Any());
        }

        [Fact]
        public void UsuarioIsInvalid()
        {
            var pessoa = new Pessoa()
            {
                Nome = "Elvis Augusto",
                Sobrenome = "Lima",
                Email = "elvislima_@hotmail.com",
                Cpf = "1234567890123456"
            };

            Assert.False(pessoa.IsValid(out var listValidationErrors));
            Assert.True(listValidationErrors.Any());
        }
    }
}
