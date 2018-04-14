using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Validations.Specifications.FabricanteSpecs.IsValid;

namespace GestaoJogos.Domain.Validations.Validations.IsValid
{
    public sealed class FabricanteIsValidValidation : Validation<Fabricante>
    {
        public FabricanteIsValidValidation()
        {
            AddRule(new ValidationRule<Fabricante>(new NomeIsValidSpec()));
        }
    }
}