using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.EmprestimoSpecs.IsRequired
{
    public class JogoIdIsRequiredSpec : ISpecification<Emprestimo>
    {
        public ValidationRuleReturn IsSatisfiedBy(Emprestimo entity)
        {
            return new ValidationRuleReturn
            {
                Valid = RequiredValidation.IsValid(entity.JogoId),
                Field = "JogoId",
                MessageError = "O jogo deve ser informado"
            };
        }
    }
}