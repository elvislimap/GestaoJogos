using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Interfaces.Specifications
{
    public interface ISpecification<in TEntity>
    {
        ValidationRuleReturn IsSatisfiedBy(TEntity entity);
    }
}