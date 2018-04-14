using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.UsuarioSpecs.IsValid
{
    public class NomeIsValidSpec : ISpecification<Usuario>
    {
        public ValidationRuleReturn IsSatisfiedBy(Usuario entity)
        {
            return new ValidationRuleReturn
            {
                Valid = LengthValidation.IsValid(entity.Nome, 60),
                Field = "Nome",
                MessageError = "O nome deve conter no máximo 60 caracteres"
            };
        }
    }
}