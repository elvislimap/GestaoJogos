using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.FabricanteSpecs.IsRequired
{
    public class NomeIsRequiredSpec : ISpecification<Fabricante>
    {
        public ValidationRuleReturn IsSatisfiedBy(Fabricante entity)
        {
            return new ValidationRuleReturn
            {
                Valid = RequiredValidation.IsValid(entity.Nome),
                Field = "Nome",
                MessageError = "O nome deve ser informado"
            };
        }
    }
}