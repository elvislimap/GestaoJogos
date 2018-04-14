using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Interfaces.Validations;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations
{
    public class ValidationRule<TEntity> : IValidationRule<TEntity>
    {
        private readonly ISpecification<TEntity> _specificationRule;

        public ValidationRule(ISpecification<TEntity> specificationRule)
        {
            _specificationRule = specificationRule;
        }

        public ValidationRuleReturn Valid(TEntity entity)
        {
            return _specificationRule.IsSatisfiedBy(entity);
        }
    }
}