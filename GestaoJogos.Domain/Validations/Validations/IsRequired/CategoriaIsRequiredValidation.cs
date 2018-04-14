using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Validations.Specifications.CategoriaSpecs.IsRequired;

namespace GestaoJogos.Domain.Validations.Validations.IsRequired
{
    public sealed class CategoriaIsRequiredValidation : Validation<Categoria>
    {
        public CategoriaIsRequiredValidation()
        {
            AddRule(new ValidationRule<Categoria>(new DescricaoIsRequiredSpec()));
        }
    }
}