using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.EnderecoSpecs.IsValid
{
    public class CepIsValidSpec : ISpecification<Endereco>
    {
        public ValidationRuleReturn IsSatisfiedBy(Endereco entity)
        {
            return new ValidationRuleReturn
            {
                Valid = LengthValidation.IsValid(entity.Cep, 10),
                Field = "Cep",
                MessageError = "O CEP deve conter no máximo 10 caracteres"
            };
        }
    }
}