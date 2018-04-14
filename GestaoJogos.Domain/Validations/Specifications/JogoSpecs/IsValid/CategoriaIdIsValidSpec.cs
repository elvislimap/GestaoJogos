using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.JogoSpecs.IsValid
{
    public class CategoriaIdIsValidSpec : ISpecification<Jogo>
    {
        public ValidationRuleReturn IsSatisfiedBy(Jogo entity)
        {
            return new ValidationRuleReturn
            {
                Valid = IntegerValidation.IsValid(entity.CategoriaId),
                Field = "CategoriaId",
                MessageError = "A categoria selecionada é inválida"
            };
        }
    }
}