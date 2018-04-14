using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.EnderecoSpecs.IsValid
{
    public class BairroIsValidSpec : ISpecification<Endereco>
    {
        public ValidationRuleReturn IsSatisfiedBy(Endereco entity)
        {
            return new ValidationRuleReturn
            {
                Valid = LengthValidation.IsValid(entity.Bairro, 60),
                Field = "Bairro",
                MessageError = "O bairro deve conter no máximo 60 caracteres"
            };
        }
    }
}