using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Validations.Specifications.DevolucaoSpecs.IsValid;

namespace GestaoJogos.Domain.Validations.Validations.IsValid
{
    public sealed class DevolucaoIsValidValidation : Validation<Devolucao>
    {
        public DevolucaoIsValidValidation()
        {
            AddRule(new ValidationRule<Devolucao>(new AvaliacaoIsValidSpec()));
        }
    }
}