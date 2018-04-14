using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.DevolucaoSpecs.IsValid
{
    public class AvaliacaoIsValidSpec : ISpecification<Devolucao>
    {
        public ValidationRuleReturn IsSatisfiedBy(Devolucao entity)
        {
            return new ValidationRuleReturn
            {
                Valid = entity.Avaliacao >= 0 && entity.Avaliacao <= 5,
                Field = "Avaliacao",
                MessageError = "A avaliação deve ser entre 0 e 5"
            };
        }
    }
}