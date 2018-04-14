using GestaoJogos.Domain.Entities;
using GestaoJogos.Domain.Interfaces.Specifications;
using GestaoJogos.Domain.Validations.Validations.Commons;
using GestaoJogos.Domain.ValuesObjects;

namespace GestaoJogos.Domain.Validations.Specifications.EmprestimoSpecs.IsRequired
{
    public class PessoaIdIsRequiredSpec : ISpecification<Emprestimo>
    {
        public ValidationRuleReturn IsSatisfiedBy(Emprestimo entity)
        {
            return new ValidationRuleReturn
            {
                Valid = RequiredValidation.IsValid(entity.PessoaId),
                Field = "PessoaId",
                MessageError = "O amigo deve ser informado"
            };
        }
    }
}