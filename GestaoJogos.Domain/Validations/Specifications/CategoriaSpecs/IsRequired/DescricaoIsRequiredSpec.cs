using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.CategoriaSpecs.IsRequired
{
    public class DescricaoIsRequiredSpec : ISpecification<Categoria>
    {
        public ValidationRuleReturn IsSatisfiedBy(Categoria entity)
        {
            return new ValidationRuleReturn
            {
                Valid = RequiredValidation.IsValid(entity.Descricao),
                Field = "Descricao",
                MessageError = "O campo descrição deve ser informado"
            };
        }
    }
}