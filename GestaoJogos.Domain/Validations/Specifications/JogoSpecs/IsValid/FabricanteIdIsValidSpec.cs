using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.JogoSpecs.IsValid
{
    public class FabricanteIdIsValidSpec : ISpecification<Jogo>
    {
        public ValidationRuleReturn IsSatisfiedBy(Jogo entity)
        {
            return new ValidationRuleReturn
            {
                Valid = IntegerValidation.IsValid(entity.FabricanteId),
                Field = "FabricanteId",
                MessageError = "O fabricante selecionado é inválido"
            };
        }
    }
}