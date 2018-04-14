using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Interfaces.Validations
{
    public interface IValidationRule<in TEntity>
    {
        ValidationRuleReturn Valid(TEntity entity);
    }
}