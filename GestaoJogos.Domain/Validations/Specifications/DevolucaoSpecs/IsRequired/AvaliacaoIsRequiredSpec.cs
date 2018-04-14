using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.DevolucaoSpecs.IsRequired
{
    public class AvaliacaoIsRequiredSpec : ISpecification<Devolucao>
    {
        public ValidationRuleReturn IsSatisfiedBy(Devolucao entity)
        {
            return new ValidationRuleReturn
            {
                Valid = RequiredValidation.IsValid(entity.Avaliacao),
                Field = "Avaliacao",
                MessageError = "A avaliação deve ser informada"
            };
        }
    }
}