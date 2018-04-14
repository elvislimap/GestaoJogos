using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Validations.Specifications.DevolucaoSpecs.IsRequired;

namespace GestaoJogos.Domain.Validations.Validations.IsRequired
{
    public sealed class DevolucaoIsRequiredValidation : Validation<Devolucao>
    {
        public DevolucaoIsRequiredValidation()
        {
            AddRule(new ValidationRule<Devolucao>(new AvaliacaoIsRequiredSpec()));
        }
    }
}