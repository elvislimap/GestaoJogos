using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Validations.Specifications.CategoriaSpecs.IsValid;

namespace GestaoJogos.Domain.Validations.Validations.IsValid
{
    public sealed class CategoriaIsValidValidation : Validation<Categoria>
    {
        public CategoriaIsValidValidation()
        {
            AddRule(new ValidationRule<Categoria>(new DescricaoIsValidSpec()));
        }
    }
}