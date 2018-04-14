using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Validations.Specifications.FabricanteSpecs.IsRequired;

namespace GestaoJogos.Domain.Validations.Validations.IsRequired
{
    public sealed class FabricanteIsRequiredValidation : Validation<Fabricante>
    {
        public FabricanteIsRequiredValidation()
        {
            AddRule(new ValidationRule<Fabricante>(new NomeIsRequiredSpec()));
        }
    }
}