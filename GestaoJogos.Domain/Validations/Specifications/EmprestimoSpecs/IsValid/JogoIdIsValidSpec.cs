using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.EmprestimoSpecs.IsValid
{
    public class JogoIdIsValidSpec : ISpecification<Emprestimo>
    {
        public ValidationRuleReturn IsSatisfiedBy(Emprestimo entity)
        {
            return new ValidationRuleReturn
            {
                Valid = IntegerValidation.IsValid(entity.JogoId),
                Field = "JogoId",
                MessageError = "O jogo selecionado é inválido"
            };
        }
    }
}