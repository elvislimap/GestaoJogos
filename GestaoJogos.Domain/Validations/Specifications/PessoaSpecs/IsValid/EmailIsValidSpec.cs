using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.PessoaSpecs.IsValid
{
    public class EmailIsValidSpec : ISpecification<Pessoa>
    {
        public ValidationRuleReturn IsSatisfiedBy(Pessoa entity)
        {
            return new ValidationRuleReturn
            {
                Valid = EmailValidation.IsValid(entity.Email, 80),
                Field = "Email",
                MessageError = "O e-mail é inválido"
            };
        }
    }
}