using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.EnderecoSpecs.IsRequired
{
    public class UfIsRequiredSpec : ISpecification<Endereco>
    {
        public ValidationRuleReturn IsSatisfiedBy(Endereco entity)
        {
            return new ValidationRuleReturn
            {
                Valid = RequiredValidation.IsValid(entity.Uf),
                Field = "Uf",
                MessageError = "O uf deve ser informado"
            };
        }
    }
}