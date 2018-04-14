using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.PessoaSpecs.IsValid
{
    public class SobrenomeIsValidSpec : ISpecification<Pessoa>
    {
        public ValidationRuleReturn IsSatisfiedBy(Pessoa entity)
        {
            return new ValidationRuleReturn
            {
                Valid = LengthValidation.IsValid(entity.Sobrenome, 60),
                Field = "Sobrenome",
                MessageError = "O nome deve conter no máximo 60 caracteres"
            };
        }
    }
}