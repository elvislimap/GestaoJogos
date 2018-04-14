using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.FabricanteSpecs.IsValid
{
    public class NomeIsValidSpec : ISpecification<Fabricante>
    {
        public ValidationRuleReturn IsSatisfiedBy(Fabricante entity)
        {
            return new ValidationRuleReturn
            {
                Valid = LengthValidation.IsValid(entity.Nome, 80),
                Field = "Nome",
                MessageError = "O nome deve conter no máximo 80 caracteres"
            };
        }
    }
}