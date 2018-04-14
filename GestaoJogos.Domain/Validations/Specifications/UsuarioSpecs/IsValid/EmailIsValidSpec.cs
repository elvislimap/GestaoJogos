using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.UsuarioSpecs.IsValid
{
    public class EmailIsValidSpec : ISpecification<Usuario>
    {
        public ValidationRuleReturn IsSatisfiedBy(Usuario entity)
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