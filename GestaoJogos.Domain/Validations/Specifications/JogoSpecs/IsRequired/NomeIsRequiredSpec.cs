using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.JogoSpecs.IsRequired
{
    public class NomeIsRequiredSpec : ISpecification<Jogo>
    {
        public ValidationRuleReturn IsSatisfiedBy(Jogo entity)
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