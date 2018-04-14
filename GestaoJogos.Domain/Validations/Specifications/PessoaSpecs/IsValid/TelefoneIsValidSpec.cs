using GestaoJogos.Domain.Commons;
using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.PessoaSpecs.IsValid
{
    public class TelefoneIsValidSpec : ISpecification<Pessoa>
    {
        public ValidationRuleReturn IsSatisfiedBy(Pessoa entity)
        {
            return new ValidationRuleReturn
            {
                Valid = LengthValidation.IsValid(entity.Telefone.OnlyNumbers(), 11),
                Field = "Telefone",
                MessageError = "O telefone deve conter no máximo 11 caracteres"
            };
        }
    }
}