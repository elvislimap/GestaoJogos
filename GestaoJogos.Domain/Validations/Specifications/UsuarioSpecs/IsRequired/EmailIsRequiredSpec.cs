using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.UsuarioSpecs.IsRequired
{
    public class EmailIsRequiredSpec : ISpecification<Usuario>
    {
        public ValidationRuleReturn IsSatisfiedBy(Usuario entity)
        {
            return new ValidationRuleReturn
            {
                Valid = RequiredValidation.IsValid(entity.Email),
                Field = "Email",
                MessageError = "O e-mail deve ser informado"
            };
        }
    }
}