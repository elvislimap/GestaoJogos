using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.UsuarioSpecs.IsValid
{
    public class SenhaIsValidSpec : ISpecification<Usuario>
    {
        public ValidationRuleReturn IsSatisfiedBy(Usuario entity)
        {
            return new ValidationRuleReturn
            {
                Valid = PasswordValidation.IsValid(entity.Senha),
                Field = "Senha",
                MessageError = "A senha deve conter no mínimo 8 e máximo 16 caracteres"
            };
        }
    }
}