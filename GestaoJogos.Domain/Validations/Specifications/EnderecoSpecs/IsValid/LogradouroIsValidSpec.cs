using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.EnderecoSpecs.IsValid
{
    public class LogradouroIsValidSpec : ISpecification<Endereco>
    {
        public ValidationRuleReturn IsSatisfiedBy(Endereco entity)
        {
            return new ValidationRuleReturn
            {
                Valid = LengthValidation.IsValid(entity.Logradouro, 80),
                Field = "Logradouro",
                MessageError = "O logradouro deve conter no máximo 80 caracteres"
            };
        }
    }
}