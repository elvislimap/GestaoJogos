using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.EnderecoSpecs.IsValid
{
    public class MunicipioIsValidSpec : ISpecification<Endereco>
    {
        public ValidationRuleReturn IsSatisfiedBy(Endereco entity)
        {
            return new ValidationRuleReturn
            {
                Valid = LengthValidation.IsValid(entity.Municipio, 80),
                Field = "Municipio",
                MessageError = "O município é inválido"
            };
        }
    }
}