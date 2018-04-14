using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.JogoSpecs.IsValid
{
    public class NomeIsValidSpec : ISpecification<Jogo>
    {
        public ValidationRuleReturn IsSatisfiedBy(Jogo entity)
        {
            return new ValidationRuleReturn
            {
                Valid = LengthValidation.IsValid(entity.Nome, 150),
                Field = "Nome",
                MessageError = "O nome deve conter no máximo 150 caracteres"
            };
        }
    }
}