using GestaoJogos.Domain.Validations;

namespace GestaoJogos.Domain.Interfaces.Validations
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Execute(TEntity entity);
    }
}